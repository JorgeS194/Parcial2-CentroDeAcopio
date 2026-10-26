using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2.Negocio
{
    public class LogicaDonaciones
    {
        // Valida los datos antes de registrar una donación.
        public void ValidarDonacion(
            string nombreProducto,
            string descripcion,
            string tipoDonacion,
            int cantidad,
            string talla,
            string destinatario,
            string sexo)
        {
            // Validar el nombre del producto.
            if (string.IsNullOrWhiteSpace(nombreProducto))
            {
                throw new ArgumentException(
                    "Debe ingresar el nombre del producto.");
            }

            // Validar la descripción.
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException(
                    "Debe ingresar una descripción.");
            }

            // Validar el tipo de donación.
            ValidarTipoDonacion(tipoDonacion);

            // La cantidad debe ser un entero positivo.
            if (cantidad <= 0)
            {
                throw new ArgumentException(
                    "La cantidad donada debe ser mayor que cero.");
            }

            // Los datos adicionales solo son obligatorios
            // cuando la donación es de tipo Ropa.
            if (tipoDonacion.Trim().Equals(
                "Ropa", StringComparison.OrdinalIgnoreCase))
            {
                ValidarDatosRopa(talla, destinatario, sexo);
            }
        }

        // Verifica que el tipo de donación sea válido.
        public void ValidarTipoDonacion(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
            {
                throw new ArgumentException(
                    "Debe seleccionar el tipo de donación.");
            }

            string valor = tipo.Trim();

            if (!valor.Equals("Alimentos", StringComparison.OrdinalIgnoreCase) &&
                !valor.Equals("Ropa", StringComparison.OrdinalIgnoreCase) &&
                !valor.Equals("Insumos", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    "El tipo debe ser Alimentos, Ropa o Insumos.");
            }
        }

        // Valida los campos adicionales de las donaciones de ropa.
        private void ValidarDatosRopa(
            string talla,
            string destinatario,
            string sexo)
        {
            if (string.IsNullOrWhiteSpace(talla))
            {
                throw new ArgumentException(
                    "Debe seleccionar una talla.");
            }

            string tallaSeleccionada = talla.Trim().ToUpper();

            if (tallaSeleccionada != "XS" &&
                tallaSeleccionada != "S" &&
                tallaSeleccionada != "M" &&
                tallaSeleccionada != "L" &&
                tallaSeleccionada != "XL")
            {
                throw new ArgumentException(
                    "La talla debe ser XS, S, M, L o XL.");
            }

            if (string.IsNullOrWhiteSpace(destinatario))
            {
                throw new ArgumentException(
                    "Debe indicar si la ropa es para Niño o Adulto.");
            }

            string destino = destinatario.Trim();

            if (!destino.Equals("Niño", StringComparison.OrdinalIgnoreCase) &&
                !destino.Equals("Adulto", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    "El destinatario debe ser Niño o Adulto.");
            }

            if (string.IsNullOrWhiteSpace(sexo))
            {
                throw new ArgumentException(
                    "Debe seleccionar Hombre, Mujer o Unisex.");
            }

            string sexoSeleccionado = sexo.Trim();

            if (!sexoSeleccionado.Equals("Hombre", StringComparison.OrdinalIgnoreCase) &&
                !sexoSeleccionado.Equals("Mujer", StringComparison.OrdinalIgnoreCase) &&
                !sexoSeleccionado.Equals("Unisex", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    "El sexo debe ser Hombre, Mujer o Unisex.");
            }
        }

        // Prepara el filtro por talla para los reportes.
        // Cuando seleccionan Todos, devuelve null.
        public string PrepararFiltroTalla(string talla)
        {
            if (string.IsNullOrWhiteSpace(talla))
            {
                throw new ArgumentException(
                    "Debe seleccionar una talla o Todos.");
            }

            string valor = talla.Trim().ToUpper();

            if (valor == "TODOS")
                return null;

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

        // Prepara el filtro por sexo para los reportes.
        // Cuando seleccionan Todos, devuelve null.
        public string PrepararFiltroSexo(string sexo)
        {
            if (string.IsNullOrWhiteSpace(sexo))
            {
                throw new ArgumentException(
                    "Debe seleccionar un sexo o Todos.");
            }

            string valor = sexo.Trim();

            if (valor.Equals("Todos", StringComparison.OrdinalIgnoreCase))
                return null;

            if (!valor.Equals("Hombre", StringComparison.OrdinalIgnoreCase) &&
                !valor.Equals("Mujer", StringComparison.OrdinalIgnoreCase) &&
                !valor.Equals("Unisex", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    "El filtro de sexo no es válido.");
            }

            return valor;
        }


        // Prepara el tipo de donación para el reporte.
        public string PrepararFiltroTipo(string tipo)
        {
            // Reutilizamos la validación que ya tenemos.
            ValidarTipoDonacion(tipo);

            string valor = tipo.Trim();

            // Devolvemos el nombre con un formato uniforme.
            if (valor.Equals("Alimentos",
                StringComparison.OrdinalIgnoreCase))
            {
                return "Alimentos";
            }

            if (valor.Equals("Ropa",
                StringComparison.OrdinalIgnoreCase))
            {
                return "Ropa";
            }

            return "Insumos";
        }

    }
}
