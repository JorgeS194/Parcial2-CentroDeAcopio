using CentroAcopio.Entidades;
using CentroAcopio.Negocio;
using Parcial2;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace CentroAcopio.Presentacion
{
    public partial class FormRegistro : Form
    {
        private readonly DonacionNegocio _negocio = new DonacionNegocio();

        public FormRegistro()
        {
            InitializeComponent();
        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {
            gboxRopa.Visible = false;
            gboxRopa.Enabled = false;
            cboxTipo.SelectedIndex = -1;
            txtNombre.Focus();
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            ValidarNombre();
        }

        private void txtDescripcion_Validating(object sender, CancelEventArgs e)
        {
            ValidarDescripcion();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            ValidarCantidad();
        }

        private void cboxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esRopa = EsRopa();
            gboxRopa.Visible = esRopa;
            gboxRopa.Enabled = esRopa;

            if (!esRopa)
            {
                LimpiarDatosRopa();
            }

            if (cboxTipo.SelectedIndex != -1)
            {
                errorProTipoDonacion.SetError(cboxTipo, string.Empty);
            }
        }

        private void cboxTipo_Validating(object sender, CancelEventArgs e)
        {
            ValidarTipo();
        }

        private void cboxTalla_Validating(object sender, CancelEventArgs e)
        {
            ValidarTalla();
        }

        private void cboxEdad_Validating(object sender, CancelEventArgs e)
        {
            ValidarEdad();
        }

        private void cboxSexo_Validating(object sender, CancelEventArgs e)
        {
            ValidarSexo();
        }

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarFormulario())
                {
                    MessageBox.Show("Complete correctamente los campos marcados con el ícono de error.",
                        "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Donacion donacion = CrearDonacion();
                int codigo = _negocio.RegistrarDonacion(donacion);

                MessageBox.Show("La donación se registró correctamente." + Environment.NewLine +
                    "Código de donación: " + codigo,
                    "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Datos no válidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo registrar la donación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("La cantidad ingresada no tiene un formato numérico válido.",
                    "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error inesperado al registrar la donación. Intente nuevamente.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btConsultarDonaciones_Click(object sender, EventArgs e)
        {
            using (FormConsultas formConsultas = new FormConsultas())
            {
                Hide();
                formConsultas.ShowDialog(this);
                Show();
            }
        }

        private bool EsRopa()
        {
            return cboxTipo.SelectedItem != null && cboxTipo.SelectedItem.ToString() == "Ropa";
        }

        private bool ValidarFormulario()
        {
            bool[] resultados =
            {
                ValidarNombre(),
                ValidarDescripcion(),
                ValidarCantidad(),
                ValidarTipo(),
                ValidarTalla(),
                ValidarEdad(),
                ValidarSexo()
            };

            Control[] controles = { txtNombre, txtDescripcion, txtCantidad, cboxTipo, cboxTalla, cboxEdad, cboxSexo };

            for (int i = 0; i < resultados.Length; i++)
            {
                if (!resultados[i])
                {
                    controles[i].Focus();
                    return false;
                }
            }

            return true;
        }

        private bool ValidarNombre()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProNombre.SetError(txtNombre, "Ingrese el nombre del producto.");
                return false;
            }

            errorProNombre.SetError(txtNombre, string.Empty);
            return true;
        }

        private bool ValidarDescripcion()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                errorProDescripcion.SetError(txtDescripcion, "Ingrese la descripción del producto.");
                return false;
            }

            errorProDescripcion.SetError(txtDescripcion, string.Empty);
            return true;
        }

        private bool ValidarCantidad()
        {
            string texto = txtCantidad.Text.Trim();
            int cantidad;

            if (texto.Length == 0)
            {
                errorProCantidad.SetError(txtCantidad, "Ingrese la cantidad donada.");
                return false;
            }

            if (!int.TryParse(texto, NumberStyles.None, CultureInfo.InvariantCulture, out cantidad))
            {
                errorProCantidad.SetError(txtCantidad, "La cantidad debe ser un número entero, sin signos ni decimales.");
                return false;
            }

            if (cantidad <= 0)
            {
                errorProCantidad.SetError(txtCantidad, "La cantidad debe ser mayor que cero.");
                return false;
            }

            errorProCantidad.SetError(txtCantidad, string.Empty);
            return true;
        }

        private bool ValidarTipo()
        {
            if (cboxTipo.SelectedIndex == -1)
            {
                errorProTipoDonacion.SetError(cboxTipo, "Seleccione el tipo de donación.");
                return false;
            }

            errorProTipoDonacion.SetError(cboxTipo, string.Empty);
            return true;
        }

        private bool ValidarTalla()
        {
            if (EsRopa() && cboxTalla.SelectedIndex == -1)
            {
                errorProTalla.SetError(cboxTalla, "Seleccione la talla de la prenda.");
                return false;
            }

            errorProTalla.SetError(cboxTalla, string.Empty);
            return true;
        }

        private bool ValidarEdad()
        {
            if (EsRopa() && cboxEdad.SelectedIndex == -1)
            {
                errorProEdad.SetError(cboxEdad, "Indique si la prenda es para niño o adulto.");
                return false;
            }

            errorProEdad.SetError(cboxEdad, string.Empty);
            return true;
        }

        private bool ValidarSexo()
        {
            if (EsRopa() && cboxSexo.SelectedIndex == -1)
            {
                errorProSexo.SetError(cboxSexo, "Indique si la prenda es para hombre, mujer o unisex.");
                return false;
            }

            errorProSexo.SetError(cboxSexo, string.Empty);
            return true;
        }

        private Donacion CrearDonacion()
        {
            string nombre = txtNombre.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            string tipo = cboxTipo.SelectedItem.ToString();
            int cantidad = int.Parse(txtCantidad.Text.Trim(), NumberStyles.None, CultureInfo.InvariantCulture);

            if (EsRopa())
            {
                return new DonacionRopa
                {
                    NombreProducto = nombre,
                    Descripcion = descripcion,
                    TipoDonacion = tipo,
                    Cantidad = cantidad,
                    Talla = cboxTalla.SelectedItem.ToString(),
                    GrupoEdad = cboxEdad.SelectedItem.ToString(),
                    Sexo = cboxSexo.SelectedItem.ToString()
                };
            }

            return new Donacion
            {
                NombreProducto = nombre,
                Descripcion = descripcion,
                TipoDonacion = tipo,
                Cantidad = cantidad
            };
        }

        private void LimpiarDatosRopa()
        {
            cboxTalla.SelectedIndex = -1;
            cboxEdad.SelectedIndex = -1;
            cboxSexo.SelectedIndex = -1;
            errorProTalla.SetError(cboxTalla, string.Empty);
            errorProEdad.SetError(cboxEdad, string.Empty);
            errorProSexo.SetError(cboxSexo, string.Empty);
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtCantidad.Clear();
            cboxTipo.SelectedIndex = -1;
            LimpiarDatosRopa();
            errorProNombre.SetError(txtNombre, string.Empty);
            errorProDescripcion.SetError(txtDescripcion, string.Empty);
            errorProCantidad.SetError(txtCantidad, string.Empty);
            errorProTipoDonacion.SetError(cboxTipo, string.Empty);
            txtNombre.Focus();
        }
    }
}