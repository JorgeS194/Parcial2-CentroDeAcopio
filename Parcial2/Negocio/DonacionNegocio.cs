
using CentroAcopio.Datos;
using CentroAcopio.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CentroAcopio.Negocio
{
    public class DonacionNegocio
    {
        // Objetos que permiten comunicarse con la capa de datos.
        private readonly DonacionDatos datosDonacion;
        private readonly DonacionRopaDatos datosRopa;

        public DonacionNegocio()
        {
            datosDonacion = new DonacionDatos();
            datosRopa = new DonacionRopaDatos();
        }

        // REGISTRAR DONACIÓN
        public int RegistrarDonacion(Donacion donacion)
        {
            if (donacion == null)
            {
                throw new ArgumentNullException(
                    nameof(donacion),
                    "La donación no puede estar vacía.");
            }

            ValidarTipoDonacion(donacion.TipoDonacion);

            bool esRopa = donacion.TipoDonacion.Trim().Equals(
                "Ropa", StringComparison.OrdinalIgnoreCase);

            // Comprobamos si es una donación de ropa.
            DonacionRopa ropa = donacion as DonacionRopa;

            if (esRopa && ropa == null)
            {
                throw new ArgumentException(
                    "Las donaciones de ropa requieren talla, grupo de edad y sexo.");
            }

            if (!esRopa && ropa != null)
            {
                throw new ArgumentException(
                    "Los datos de ropa solo corresponden a donaciones de tipo Ropa.");
            }

            // Validamos los datos antes de guardarlos.
            ValidarDonacion(
                donacion.NombreProducto,
                donacion.Descripcion,
                donacion.TipoDonacion,
                donacion.Cantidad,
                ropa != null ? ropa.Talla : null,
                ropa != null ? ropa.GrupoEdad : null,
                ropa != null ? ropa.Sexo : null);

            // Quitamos espacios y normalizamos los valores.
            donacion.NombreProducto = donacion.NombreProducto.Trim();
            donacion.Descripcion = donacion.Descripcion.Trim();
            donacion.TipoDonacion =
                PrepararFiltroTipo(donacion.TipoDonacion);

            if (ropa != null)
            {
                ropa.Talla = ropa.Talla.Trim().ToUpperInvariant();

                if (ropa.GrupoEdad.Trim().Equals(
                    "Niño", StringComparison.OrdinalIgnoreCase))
                {
                    ropa.GrupoEdad = "Niño";
                }
                else
                {
                    ropa.GrupoEdad = "Adulto";
                }

                if (ropa.Sexo.Trim().Equals(
                    "Hombre", StringComparison.OrdinalIgnoreCase))
                {
                    ropa.Sexo = "Hombre";
                }
                else if (ropa.Sexo.Trim().Equals(
                    "Mujer", StringComparison.OrdinalIgnoreCase))
                {
                    ropa.Sexo = "Mujer";
                }
                else
                {
                    ropa.Sexo = "Unisex";
                }
            }

            try
            {
                // Ejecuta el procedimiento almacenado
                // dbo.usp_Donacion_Registrar.
                // Devuelve el ID generado por SQL Server.
                return datosDonacion.Registrar(donacion);
            }
            catch (SqlException ex)
            {
                throw ManejarErrorSql(ex);
            }
        }

        // REPORTE 1: TOTAL DE UNIDADES POR TIPO
        public DataTable ObtenerTotalPorTipo()
        {
            try
            {
                return datosDonacion.ObtenerTotalPorTipo();
            }
            catch (SqlException ex)
            {
                throw ManejarErrorSql(ex);
            }
        }

        // REPORTE 2: DONACIONES DE UN TIPO
        public DataTable ListarPorTipo(string tipo)
        {
            string tipoValido = PrepararFiltroTipo(tipo);

            try
            {
                return datosDonacion.ListarPorTipo(tipoValido);
            }
            catch (SqlException ex)
            {
                throw ManejarErrorSql(ex);
            }
        }

        // REPORTE 3: ROPA FILTRADA POR TALLA Y SEXO
        public DataTable FiltrarRopa(string talla, string sexo)
        {
            // Cuando se selecciona Todos, el filtro será null.
            string tallaValida = PrepararFiltroTalla(talla);
            string sexoValido = PrepararFiltroSexo(sexo);

            try
            {
                return datosRopa.FiltrarRopa(
                    tallaValida, sexoValido);
            }
            catch (SqlException ex)
            {
                throw ManejarErrorSql(ex);
            }
        }

        // VALIDACIONES GENERALES DE UNA DONACIÓN
        public void ValidarDonacion(
            string nombreProducto,
            string descripcion,
            string tipoDonacion,
            int cantidad,
            string talla,
            string grupoEdad,
            string sexo)
        {
            // Nombre obligatorio.
            if (string.IsNullOrWhiteSpace(nombreProducto))
            {
                throw new ArgumentException(
                    "Debe ingresar el nombre del producto.");
            }

            // Límite establecido por la base de datos.
            if (nombreProducto.Trim().Length > 150)
            {
                throw new ArgumentException(
                    "El nombre del producto no puede superar los 150 caracteres.");
            }

            // Descripción obligatoria.
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException(
                    "Debe ingresar una descripción.");
            }

            if (descripcion.Trim().Length > 500)
            {
                throw new ArgumentException(
                    "La descripción no puede superar los 500 caracteres.");
            }

            // Verificamos que el tipo sea válido.
            ValidarTipoDonacion(tipoDonacion);

            // La cantidad debe ser un entero positivo.
            if (cantidad <= 0)
            {
                throw new ArgumentException(
                    "La cantidad donada debe ser mayor que cero.");
            }

            // Datos obligatorios cuando la donación es de ropa.
            if (tipoDonacion.Trim().Equals(
                "Ropa", StringComparison.OrdinalIgnoreCase))
            {
                ValidarDatosRopa(talla, grupoEdad, sexo);
            }
            else
            {
                // Alimentos e Insumos no deben tener datos de ropa.
                if (!string.IsNullOrWhiteSpace(talla) ||
                    !string.IsNullOrWhiteSpace(grupoEdad) ||
                    !string.IsNullOrWhiteSpace(sexo))
                {
                    throw new ArgumentException(
                        "Los datos de ropa solo corresponden a donaciones de tipo Ropa.");
                }
            }
        }

        // VALIDAR TIPO DE DONACIÓN
        public void ValidarTipoDonacion(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
            {
                throw new ArgumentException(
                    "Debe seleccionar el tipo de donación.");
            }

            string valor = tipo.Trim();

            if (!valor.Equals(
                    "Alimentos", StringComparison.OrdinalIgnoreCase) &&
                !valor.Equals(
                    "Ropa", StringComparison.OrdinalIgnoreCase) &&
                !valor.Equals(
                    "Insumos", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    "El tipo debe ser Alimentos, Ropa o Insumos.");
            }
        }

        // VALIDAR LOS CAMPOS ADICIONALES DE ROPA
        private void ValidarDatosRopa(
            string talla,
            string grupoEdad,
            string sexo)
        {
            // Validar talla.
            if (string.IsNullOrWhiteSpace(talla))
            {
                throw new ArgumentException(
                    "Debe seleccionar una talla.");
            }

            string tallaSeleccionada =
                talla.Trim().ToUpperInvariant();

            if (tallaSeleccionada != "XS" &&
                tallaSeleccionada != "S" &&
                tallaSeleccionada != "M" &&
                tallaSeleccionada != "L" &&
                tallaSeleccionada != "XL")
            {
                throw new ArgumentException(
                    "La talla debe ser XS, S, M, L o XL.");
            }

            // Validar grupo de edad.
            if (string.IsNullOrWhiteSpace(grupoEdad))
            {
                throw new ArgumentException(
                    "Debe indicar si la ropa es para Niño o Adulto.");
            }

            string edadSeleccionada = grupoEdad.Trim();

            if (!edadSeleccionada.Equals(
                    "Niño", StringComparison.OrdinalIgnoreCase) &&
                !edadSeleccionada.Equals(
                    "Adulto", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    "El grupo de edad debe ser Niño o Adulto.");
            }

            // Validar sexo.
            if (string.IsNullOrWhiteSpace(sexo))
            {
                throw new ArgumentException(
                    "Debe seleccionar Hombre, Mujer o Unisex.");
            }

            string sexoSeleccionado = sexo.Trim();

            if (!sexoSeleccionado.Equals(
                    "Hombre", StringComparison.OrdinalIgnoreCase) &&
                !sexoSeleccionado.Equals(
                    "Mujer", StringComparison.OrdinalIgnoreCase) &&
                !sexoSeleccionado.Equals(
                    "Unisex", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    "El sexo debe ser Hombre, Mujer o Unisex.");
            }
        }

        // PREPARAR EL TIPO PARA EL REPORTE
        public string PrepararFiltroTipo(string tipo)
        {
            ValidarTipoDonacion(tipo);

            string valor = tipo.Trim();

            if (valor.Equals(
                "Alimentos", StringComparison.OrdinalIgnoreCase))
            {
                return "Alimentos";
            }

            if (valor.Equals(
                "Ropa", StringComparison.OrdinalIgnoreCase))
            {
                return "Ropa";
            }

            return "Insumos";
        }

        // PREPARAR FILTRO DE TALLA
        public string PrepararFiltroTalla(string talla)
        {
            if (string.IsNullOrWhiteSpace(talla))
            {
                throw new ArgumentException(
                    "Debe seleccionar una talla o Todos.");
            }

            string valor = talla.Trim().ToUpperInvariant();

            // null significa que no se aplica filtro de talla.
            if (valor == "TODOS")
            {
                return null;
            }

            if (valor != "XS" &&
                valor != "S" &&
                valor != "M" &&
                valor != "L" &&
                valor != "XL")
            {
                throw new ArgumentException(
                    "El filtro de talla no es válido.");
            }

            return valor;
        }

        // PREPARAR FILTRO DE SEXO
        public string PrepararFiltroSexo(string sexo)
        {
            if (string.IsNullOrWhiteSpace(sexo))
            {
                throw new ArgumentException(
                    "Debe seleccionar un sexo o Todos.");
            }

            string valor = sexo.Trim();

            // null significa que no se aplica filtro de sexo.
            if (valor.Equals(
                "Todos", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            if (valor.Equals(
                "Hombre", StringComparison.OrdinalIgnoreCase))
            {
                return "Hombre";
            }

            if (valor.Equals(
                "Mujer", StringComparison.OrdinalIgnoreCase))
            {
                return "Mujer";
            }

            if (valor.Equals(
                "Unisex", StringComparison.OrdinalIgnoreCase))
            {
                return "Unisex";
            }

            throw new ArgumentException(
                "El filtro de sexo no es válido.");
        }

        // MANEJO DE ERRORES DE SQL SERVER
        private Exception ManejarErrorSql(SqlException ex)
        {
            // Errores personalizados de los procedimientos
            // almacenados del compañero de base de datos.
            if (ex.Number >= 50001 && ex.Number <= 50008)
            {
                return new ArgumentException(
                    ex.Message, ex);
            }

            // SQL Server no pudo abrir la base de datos.
            // Puede no existir o faltar permisos de acceso.
            if (ex.Number == 4060 || ex.Number == 911)
            {
                return new InvalidOperationException(
                    "No se pudo abrir la base de datos CentroAcopio. " +
                    "Verifique que exista y que tenga permiso para acceder a ella.",
                    ex);
            }

            // Cualquier otro error de SQL Server.
            return new InvalidOperationException(
                "No se pudo completar la operación con SQL Server. " +
                "Verifique que el servidor esté encendido, que exista " +
                "la conexión y que los procedimientos almacenados estén disponibles.",
                ex);
        }
    }
}
