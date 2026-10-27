namespace CentroAcopio.Presentacion
{
    partial class FormConsultas
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.gboxConsultar = new System.Windows.Forms.GroupBox();
            this.gboxFiltroRopa = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboxConsultarSexo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboxConsultarTalla = new System.Windows.Forms.ComboBox();
            this.chkRopa = new System.Windows.Forms.CheckBox();
            this.cboxTipoConsulta = new System.Windows.Forms.ComboBox();
            this.chkPorTipo = new System.Windows.Forms.CheckBox();
            this.chkboxTotalPorTipo = new System.Windows.Forms.CheckBox();
            this.dgvConsultas = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.btRegresar = new System.Windows.Forms.Button();
            this.errorProTipoConsulta = new System.Windows.Forms.ErrorProvider(this.components);
            this.gboxConsultar.SuspendLayout();
            this.gboxFiltroRopa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProTipoConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label2.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(306, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(353, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "Consulta de Donaciones";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gboxConsultar
            // 
            this.gboxConsultar.Controls.Add(this.gboxFiltroRopa);
            this.gboxConsultar.Controls.Add(this.chkRopa);
            this.gboxConsultar.Controls.Add(this.cboxTipoConsulta);
            this.gboxConsultar.Controls.Add(this.chkPorTipo);
            this.gboxConsultar.Controls.Add(this.chkboxTotalPorTipo);
            this.gboxConsultar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxConsultar.Location = new System.Drawing.Point(35, 100);
            this.gboxConsultar.Name = "gboxConsultar";
            this.gboxConsultar.Size = new System.Drawing.Size(861, 193);
            this.gboxConsultar.TabIndex = 3;
            this.gboxConsultar.TabStop = false;
            this.gboxConsultar.Text = "Consultar:";
            // 
            // gboxFiltroRopa
            // 
            this.gboxFiltroRopa.Controls.Add(this.label8);
            this.gboxFiltroRopa.Controls.Add(this.cboxConsultarSexo);
            this.gboxFiltroRopa.Controls.Add(this.label6);
            this.gboxFiltroRopa.Controls.Add(this.cboxConsultarTalla);
            this.gboxFiltroRopa.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxFiltroRopa.Location = new System.Drawing.Point(619, 87);
            this.gboxFiltroRopa.Name = "gboxFiltroRopa";
            this.gboxFiltroRopa.Size = new System.Drawing.Size(221, 100);
            this.gboxFiltroRopa.TabIndex = 4;
            this.gboxFiltroRopa.TabStop = false;
            this.gboxFiltroRopa.Text = "Filtrar por:";
            this.gboxFiltroRopa.Visible = false;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(138, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 25);
            this.label8.TabIndex = 17;
            this.label8.Text = "Sexo:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboxConsultarSexo
            // 
            this.cboxConsultarSexo.BackColor = System.Drawing.Color.NavajoWhite;
            this.cboxConsultarSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxConsultarSexo.FormattingEnabled = true;
            this.cboxConsultarSexo.Items.AddRange(new object[] {
            "Todos",
            "Hombre",
            "Mujer",
            "Unisex"});
            this.cboxConsultarSexo.Location = new System.Drawing.Point(116, 58);
            this.cboxConsultarSexo.Name = "cboxConsultarSexo";
            this.cboxConsultarSexo.Size = new System.Drawing.Size(89, 23);
            this.cboxConsultarSexo.TabIndex = 17;
            this.cboxConsultarSexo.SelectedIndexChanged += new System.EventHandler(this.cboxFiltrosRopa_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "Talla:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboxConsultarTalla
            // 
            this.cboxConsultarTalla.BackColor = System.Drawing.Color.NavajoWhite;
            this.cboxConsultarTalla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxConsultarTalla.FormattingEnabled = true;
            this.cboxConsultarTalla.Items.AddRange(new object[] {
            "Todos",
            "XS",
            "S",
            "M",
            "L",
            "XL"});
            this.cboxConsultarTalla.Location = new System.Drawing.Point(17, 58);
            this.cboxConsultarTalla.Name = "cboxConsultarTalla";
            this.cboxConsultarTalla.Size = new System.Drawing.Size(76, 23);
            this.cboxConsultarTalla.TabIndex = 13;
            this.cboxConsultarTalla.SelectedIndexChanged += new System.EventHandler(this.cboxFiltrosRopa_SelectedIndexChanged);
            // 
            // checkBox3
            // 
            this.chkRopa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.chkRopa.Location = new System.Drawing.Point(619, 40);
            this.chkRopa.Name = "checkBox3";
            this.chkRopa.Size = new System.Drawing.Size(221, 41);
            this.chkRopa.TabIndex = 3;
            this.chkRopa.Text = "Donaciones de ropa";
            this.chkRopa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRopa.UseVisualStyleBackColor = false;
            this.chkRopa.CheckedChanged += new System.EventHandler(this.chkRopa_CheckedChanged);
            // 
            // cboxTipoConsulta
            // 
            this.cboxTipoConsulta.BackColor = System.Drawing.Color.NavajoWhite;
            this.cboxTipoConsulta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTipoConsulta.FormattingEnabled = true;
            this.cboxTipoConsulta.Items.AddRange(new object[] {
            "Alimentos",
            "Ropa",
            "Insumos"});
            this.cboxTipoConsulta.Location = new System.Drawing.Point(317, 87);
            this.cboxTipoConsulta.Name = "cboxTipoConsulta";
            this.cboxTipoConsulta.Size = new System.Drawing.Size(270, 26);
            this.cboxTipoConsulta.TabIndex = 2;
            this.cboxTipoConsulta.Visible = false;
            this.cboxTipoConsulta.SelectedIndexChanged += new System.EventHandler(this.cboxTipoConsulta_SelectedIndexChanged);
            // 
            // chkPorTipo
            // 
            this.chkPorTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.chkPorTipo.Location = new System.Drawing.Point(317, 40);
            this.chkPorTipo.Name = "chkPorTipo";
            this.chkPorTipo.Size = new System.Drawing.Size(270, 41);
            this.chkPorTipo.TabIndex = 1;
            this.chkPorTipo.Text = "Donaciones de un solo tipo (elegir)";
            this.chkPorTipo.UseVisualStyleBackColor = false;
            this.chkPorTipo.CheckedChanged += new System.EventHandler(this.chkPorTipo_CheckedChanged);
            // 
            // chkboxTotalPorTipo
            // 
            this.chkboxTotalPorTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.chkboxTotalPorTipo.Location = new System.Drawing.Point(19, 40);
            this.chkboxTotalPorTipo.Name = "chkboxTotalPorTipo";
            this.chkboxTotalPorTipo.Size = new System.Drawing.Size(262, 41);
            this.chkboxTotalPorTipo.TabIndex = 0;
            this.chkboxTotalPorTipo.Text = "Total de donaciones por cada tipo (alimentos, ropa e insumos)";
            this.chkboxTotalPorTipo.UseVisualStyleBackColor = false;
            this.chkboxTotalPorTipo.CheckedChanged += new System.EventHandler(this.chkboxTotalPorTipo_CheckedChanged);
            // 
            // dgvConsultas
            // 
            this.dgvConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultas.Location = new System.Drawing.Point(35, 343);
            this.dgvConsultas.Name = "dgvConsultas";
            this.dgvConsultas.Size = new System.Drawing.Size(861, 190);
            this.dgvConsultas.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(412, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Resultados:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btRegresar
            // 
            this.btRegresar.BackColor = System.Drawing.Color.Red;
            this.btRegresar.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRegresar.Location = new System.Drawing.Point(26, 12);
            this.btRegresar.Name = "btRegresar";
            this.btRegresar.Size = new System.Drawing.Size(96, 33);
            this.btRegresar.TabIndex = 6;
            this.btRegresar.Text = "<- Regresar";
            this.btRegresar.UseVisualStyleBackColor = false;
            this.btRegresar.Click += new System.EventHandler(this.btRegresar_Click);
            // 
            // errorProTipoConsulta
            // 
            this.errorProTipoConsulta.ContainerControl = this;
            // 
            // FormConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.btRegresar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvConsultas);
            this.Controls.Add(this.gboxConsultar);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormConsultas";
            this.Text = "Jorge Sarmiento (3-757-1758), Abrahan Tuñon (8-1025-1064) y Moisés Murgas (8-1003" +
    "-179)";
            this.Load += new System.EventHandler(this.FormConsultas_Load);
            this.gboxConsultar.ResumeLayout(false);
            this.gboxFiltroRopa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProTipoConsulta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gboxConsultar;
        private System.Windows.Forms.CheckBox chkboxTotalPorTipo;
        private System.Windows.Forms.CheckBox chkPorTipo;
        private System.Windows.Forms.ComboBox cboxTipoConsulta;
        private System.Windows.Forms.CheckBox chkRopa;
        private System.Windows.Forms.ComboBox cboxConsultarTalla;
        private System.Windows.Forms.ComboBox cboxConsultarSexo;
        private System.Windows.Forms.GroupBox gboxFiltroRopa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvConsultas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btRegresar;
        private System.Windows.Forms.ErrorProvider errorProTipoConsulta;
    }
}

