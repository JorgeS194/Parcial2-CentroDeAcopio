using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CentroAcopio.Negocio;

namespace CentroAcopio.Presentacion
{
    public partial class FormConsultas : Form
    {
        private readonly DonacionNegocio _negocio = new DonacionNegocio();
        private bool _actualizando;

        public FormConsultas()
        {
            InitializeComponent();
        }

        private void FormConsultas_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
        }

        private void chkboxTotalPorTipo_CheckedChanged(object sender, EventArgs e)
        {
            if (_actualizando)
            {
                return;
            }

            ActivarConsulta(chkboxTotalPorTipo);

            if (chkboxTotalPorTipo.Checked)
            {
                CargarTotalPorTipo();
            }
        }

        private void chkPorTipo_CheckedChanged(object sender, EventArgs e)
        {
            if (_actualizando)
            {
                return;
            }

            ActivarConsulta(chkPorTipo);
        }

        private void chkRopa_CheckedChanged(object sender, EventArgs e)
        {
            if (_actualizando)
            {
                return;
            }

            ActivarConsulta(chkRopa);

            if (chkRopa.Checked)
            {
                CargarRopaFiltrada();
            }
        }

        private void cboxTipoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_actualizando || cboxTipoConsulta.SelectedIndex == -1)
            {
                return;
            }

            errorProTipoConsulta.SetError(cboxTipoConsulta, string.Empty);
            CargarDonacionesPorTipo();
        }

        private void cboxFiltrosRopa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_actualizando)
            {
                return;
            }

            CargarRopaFiltrada();
        }

        private void btRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ActivarConsulta(CheckBox elegida)
        {
            _actualizando = true;

            try
            {
                CheckBox[] casillas = { chkboxTotalPorTipo, chkPorTipo, chkRopa };

                foreach (CheckBox casilla in casillas)
                {
                    if (casilla != elegida)
                    {
                        casilla.Checked = false;
                    }
                }

                cboxTipoConsulta.Visible = chkPorTipo.Checked;
                gboxFiltroRopa.Visible = chkRopa.Checked;
                cboxTipoConsulta.SelectedIndex = -1;
                cboxConsultarTalla.SelectedIndex = 0;
                cboxConsultarSexo.SelectedIndex = 0;

                if (chkPorTipo.Checked)
                {
                    errorProTipoConsulta.SetError(cboxTipoConsulta, "Seleccione un tipo de donación.");
                }
                else
                {
                    errorProTipoConsulta.SetError(cboxTipoConsulta, string.Empty);
                }

                LimpiarResultados();
            }
            finally
            {
                _actualizando = false;
            }
        }

        private void CargarTotalPorTipo()
        {
            try
            {
                DataTable tabla = _negocio.ObtenerTotalPorTipo();
                MostrarResultados(tabla, false);
            }
            catch (InvalidOperationException ex)
            {
                MostrarError(ex.Message);
            }
            catch (Exception)
            {
                MostrarError("Ocurrió un error inesperado al consultar los totales. Intente nuevamente.");
            }
        }

        private void CargarDonacionesPorTipo()
        {
            try
            {
                if (cboxTipoConsulta.SelectedIndex == -1)
                {
                    errorProTipoConsulta.SetError(cboxTipoConsulta, "Seleccione un tipo de donación.");
                    return;
                }

                string tipo = cboxTipoConsulta.SelectedItem.ToString();
                DataTable tabla = _negocio.ListarPorTipo(tipo);
                MostrarResultados(tabla, tipo == "Ropa");
            }
            catch (ArgumentException ex)
            {
                MostrarError(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MostrarError(ex.Message);
            }
            catch (Exception)
            {
                MostrarError("Ocurrió un error inesperado al consultar las donaciones. Intente nuevamente.");
            }
        }

        private void CargarRopaFiltrada()
        {
            try
            {
                if (cboxConsultarTalla.SelectedIndex == -1 || cboxConsultarSexo.SelectedIndex == -1)
                {
                    return;
                }

                string talla = cboxConsultarTalla.SelectedItem.ToString();
                string sexo = cboxConsultarSexo.SelectedItem.ToString();
                DataTable tabla = _negocio.FiltrarRopa(talla, sexo);
                MostrarResultados(tabla, true);
            }
            catch (ArgumentException ex)
            {
                MostrarError(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MostrarError(ex.Message);
            }
            catch (Exception)
            {
                MostrarError("Ocurrió un error inesperado al filtrar la ropa donada. Intente nuevamente.");
            }
        }

        private void MostrarResultados(DataTable tabla, bool mostrarDatosRopa)
        {
            dgvConsultas.DataSource = tabla;
            FormatearColumnas(mostrarDatosRopa);
            dgvConsultas.ClearSelection();

            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron donaciones con los criterios seleccionados.",
                    "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LimpiarResultados()
        {
            dgvConsultas.DataSource = null;
            dgvConsultas.Columns.Clear();
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error en la consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ConfigurarGrid()
        {
            dgvConsultas.ReadOnly = true;
            dgvConsultas.AllowUserToAddRows = false;
            dgvConsultas.AllowUserToDeleteRows = false;
            dgvConsultas.AllowUserToResizeRows = false;
            dgvConsultas.AllowUserToOrderColumns = false;
            dgvConsultas.MultiSelect = false;
            dgvConsultas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsultas.RowHeadersVisible = false;
            dgvConsultas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvConsultas.EnableHeadersVisualStyles = false;
            dgvConsultas.BackgroundColor = Color.FromArgb(255, 255, 192);
            dgvConsultas.BorderStyle = BorderStyle.FixedSingle;
            dgvConsultas.GridColor = Color.FromArgb(205, 133, 63);
            dgvConsultas.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvConsultas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvConsultas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvConsultas.ColumnHeadersHeight = 34;
            dgvConsultas.RowTemplate.Height = 28;

            DataGridViewCellStyle estiloEncabezado = new DataGridViewCellStyle();
            estiloEncabezado.BackColor = Color.FromArgb(255, 255, 128);
            estiloEncabezado.ForeColor = Color.Black;
            estiloEncabezado.SelectionBackColor = Color.FromArgb(255, 255, 128);
            estiloEncabezado.SelectionForeColor = Color.Black;
            estiloEncabezado.Font = new Font("Arial", 10.5F, FontStyle.Bold);
            estiloEncabezado.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConsultas.ColumnHeadersDefaultCellStyle = estiloEncabezado;

            DataGridViewCellStyle estiloCelda = new DataGridViewCellStyle();
            estiloCelda.BackColor = Color.NavajoWhite;
            estiloCelda.ForeColor = Color.Black;
            estiloCelda.SelectionBackColor = Color.FromArgb(128, 255, 128);
            estiloCelda.SelectionForeColor = Color.Black;
            estiloCelda.Font = new Font("Arial", 9.75F);
            estiloCelda.Alignment = DataGridViewContentAlignment.MiddleLeft;
            estiloCelda.Padding = new Padding(4, 0, 4, 0);
            dgvConsultas.DefaultCellStyle = estiloCelda;

            DataGridViewCellStyle estiloAlterno = new DataGridViewCellStyle(estiloCelda);
            estiloAlterno.BackColor = Color.FromArgb(255, 239, 213);
            dgvConsultas.AlternatingRowsDefaultCellStyle = estiloAlterno;
        }

        private void FormatearColumnas(bool mostrarDatosRopa)
        {
            DefinirColumna("IdDonacion", "Código", 8, DataGridViewContentAlignment.MiddleCenter, string.Empty);
            DefinirColumna("NombreProducto", "Producto", 20, DataGridViewContentAlignment.MiddleLeft, string.Empty);
            DefinirColumna("Descripcion", "Descripción", 28, DataGridViewContentAlignment.MiddleLeft, string.Empty);
            DefinirColumna("TipoDonacion", "Tipo", 12, DataGridViewContentAlignment.MiddleCenter, string.Empty);
            DefinirColumna("Cantidad", "Cantidad", 10, DataGridViewContentAlignment.MiddleRight, "N0");
            DefinirColumna("FechaRegistro", "Fecha de registro", 16, DataGridViewContentAlignment.MiddleCenter, "dd/MM/yyyy HH:mm");
            DefinirColumna("Talla", "Talla", 8, DataGridViewContentAlignment.MiddleCenter, string.Empty);
            DefinirColumna("GrupoEdad", "Edad", 9, DataGridViewContentAlignment.MiddleCenter, string.Empty);
            DefinirColumna("Sexo", "Sexo", 10, DataGridViewContentAlignment.MiddleCenter, string.Empty);
            DefinirColumna("TotalUnidades", "Total de unidades", 20, DataGridViewContentAlignment.MiddleRight, "N0");

            string[] columnasRopa = { "Talla", "GrupoEdad", "Sexo" };

            foreach (string nombre in columnasRopa)
            {
                if (dgvConsultas.Columns.Contains(nombre))
                {
                    dgvConsultas.Columns[nombre].Visible = mostrarDatosRopa;
                }
            }
        }

        private void DefinirColumna(string nombre, string encabezado, float peso,
            DataGridViewContentAlignment alineacion, string formato)
        {
            if (!dgvConsultas.Columns.Contains(nombre))
            {
                return;
            }

            DataGridViewColumn columna = dgvConsultas.Columns[nombre];
            columna.HeaderText = encabezado;
            columna.FillWeight = peso;
            columna.MinimumWidth = 55;
            columna.DefaultCellStyle.Alignment = alineacion;
            columna.DefaultCellStyle.Format = formato;
        }
    }
}