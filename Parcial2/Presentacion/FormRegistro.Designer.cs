namespace CentroAcopio.Presentacion
{
    partial class FormRegistro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.cboxTipo = new System.Windows.Forms.ComboBox();
            this.gboxRopa = new System.Windows.Forms.GroupBox();
            this.cboxSexo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboxEdad = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboxTalla = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btRegistrar = new System.Windows.Forms.Button();
            this.btConsultarDonaciones = new System.Windows.Forms.Button();
            this.errorProNombre = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProDescripcion = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProCantidad = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProTipoDonacion = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProTalla = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProEdad = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProSexo = new System.Windows.Forms.ErrorProvider(this.components);
            this.gboxRopa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProNombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProTipoDonacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProTalla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProEdad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProSexo)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label2.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(314, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(333, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Registro de Donaciones";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre del producto:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Descripción del producto:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(94, 354);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cantidad donada:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(653, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tipo de donación:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtNombre.Location = new System.Drawing.Point(271, 163);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNombre.Size = new System.Drawing.Size(243, 22);
            this.txtNombre.TabIndex = 6;
            this.txtNombre.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombre_Validating);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtDescripcion.Location = new System.Drawing.Point(271, 233);
            this.txtDescripcion.MaxLength = 500;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(243, 80);
            this.txtDescripcion.TabIndex = 7;
            this.txtDescripcion.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescripcion_Validating);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtCantidad.Location = new System.Drawing.Point(271, 354);
            this.txtCantidad.MaxLength = 6;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCantidad.Size = new System.Drawing.Size(107, 22);
            this.txtCantidad.TabIndex = 8;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantidad_Validating);
            // 
            // cboxTipo
            // 
            this.cboxTipo.BackColor = System.Drawing.Color.NavajoWhite;
            this.cboxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTipo.FormattingEnabled = true;
            this.cboxTipo.Items.AddRange(new object[] {
            "Alimentos",
            "Ropa",
            "Insumos"});
            this.cboxTipo.Location = new System.Drawing.Point(613, 160);
            this.cboxTipo.Name = "cboxTipo";
            this.cboxTipo.Size = new System.Drawing.Size(243, 24);
            this.cboxTipo.TabIndex = 9;
            this.cboxTipo.SelectedIndexChanged += new System.EventHandler(this.cboxTipo_SelectedIndexChanged);
            this.cboxTipo.Validating += new System.ComponentModel.CancelEventHandler(this.cboxTipo_Validating);
            // 
            // gboxRopa
            // 
            this.gboxRopa.Controls.Add(this.cboxSexo);
            this.gboxRopa.Controls.Add(this.label8);
            this.gboxRopa.Controls.Add(this.cboxEdad);
            this.gboxRopa.Controls.Add(this.label7);
            this.gboxRopa.Controls.Add(this.cboxTalla);
            this.gboxRopa.Controls.Add(this.label6);
            this.gboxRopa.Enabled = false;
            this.gboxRopa.Location = new System.Drawing.Point(581, 224);
            this.gboxRopa.Name = "gboxRopa";
            this.gboxRopa.Padding = new System.Windows.Forms.Padding(0);
            this.gboxRopa.Size = new System.Drawing.Size(306, 176);
            this.gboxRopa.TabIndex = 10;
            this.gboxRopa.TabStop = false;
            this.gboxRopa.Text = "Datos de la ropa donada:";
            this.gboxRopa.Visible = false;
            // 
            // cboxSexo
            // 
            this.cboxSexo.BackColor = System.Drawing.Color.NavajoWhite;
            this.cboxSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSexo.FormattingEnabled = true;
            this.cboxSexo.Items.AddRange(new object[] {
            "Hombre",
            "Mujer",
            "Unisex"});
            this.cboxSexo.Location = new System.Drawing.Point(146, 132);
            this.cboxSexo.Name = "cboxSexo";
            this.cboxSexo.Size = new System.Drawing.Size(89, 24);
            this.cboxSexo.TabIndex = 16;
            this.cboxSexo.Validating += new System.ComponentModel.CancelEventHandler(this.cboxSexo_Validating);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "Sexo:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboxEdad
            // 
            this.cboxEdad.BackColor = System.Drawing.Color.NavajoWhite;
            this.cboxEdad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxEdad.FormattingEnabled = true;
            this.cboxEdad.Items.AddRange(new object[] {
            "Niño",
            "Adulto"});
            this.cboxEdad.Location = new System.Drawing.Point(146, 86);
            this.cboxEdad.Name = "cboxEdad";
            this.cboxEdad.Size = new System.Drawing.Size(89, 24);
            this.cboxEdad.TabIndex = 14;
            this.cboxEdad.Validating += new System.ComponentModel.CancelEventHandler(this.cboxEdad_Validating);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Edad:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboxTalla
            // 
            this.cboxTalla.BackColor = System.Drawing.Color.NavajoWhite;
            this.cboxTalla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTalla.FormattingEnabled = true;
            this.cboxTalla.Items.AddRange(new object[] {
            "XS",
            "S",
            "M",
            "L",
            "XL"});
            this.cboxTalla.Location = new System.Drawing.Point(146, 40);
            this.cboxTalla.Name = "cboxTalla";
            this.cboxTalla.Size = new System.Drawing.Size(89, 24);
            this.cboxTalla.TabIndex = 12;
            this.cboxTalla.Validating += new System.ComponentModel.CancelEventHandler(this.cboxTalla_Validating);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Talla:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btRegistrar
            // 
            this.btRegistrar.BackColor = System.Drawing.Color.Lime;
            this.btRegistrar.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRegistrar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btRegistrar.Location = new System.Drawing.Point(247, 465);
            this.btRegistrar.Name = "btRegistrar";
            this.btRegistrar.Size = new System.Drawing.Size(195, 44);
            this.btRegistrar.TabIndex = 11;
            this.btRegistrar.Text = "Registrar Donación";
            this.btRegistrar.UseVisualStyleBackColor = false;
            this.btRegistrar.Click += new System.EventHandler(this.btRegistrar_Click);
            // 
            // btConsultarDonaciones
            // 
            this.btConsultarDonaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btConsultarDonaciones.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConsultarDonaciones.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btConsultarDonaciones.Location = new System.Drawing.Point(523, 465);
            this.btConsultarDonaciones.Name = "btConsultarDonaciones";
            this.btConsultarDonaciones.Size = new System.Drawing.Size(226, 44);
            this.btConsultarDonaciones.TabIndex = 12;
            this.btConsultarDonaciones.Text = "Consultar Donaciones";
            this.btConsultarDonaciones.UseVisualStyleBackColor = false;
            this.btConsultarDonaciones.Click += new System.EventHandler(this.btConsultarDonaciones_Click);
            // 
            // errorProNombre
            // 
            this.errorProNombre.ContainerControl = this;
            // 
            // errorProDescripcion
            // 
            this.errorProDescripcion.ContainerControl = this;
            // 
            // errorProCantidad
            // 
            this.errorProCantidad.ContainerControl = this;
            // 
            // errorProTipoDonacion
            // 
            this.errorProTipoDonacion.ContainerControl = this;
            // 
            // errorProTalla
            // 
            this.errorProTalla.ContainerControl = this;
            // 
            // errorProEdad
            // 
            this.errorProEdad.ContainerControl = this;
            // 
            // errorProSexo
            // 
            this.errorProSexo.ContainerControl = this;
            // 
            // FormRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.btConsultarDonaciones);
            this.Controls.Add(this.btRegistrar);
            this.Controls.Add(this.gboxRopa);
            this.Controls.Add(this.cboxTipo);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormRegistro";
            this.Text = "Jorge Sarmiento (3-757-1758), Abrahan Tuñon (8-1025-1064) y Moisés Murgas (8-1003" +
    "-179)";
            this.Load += new System.EventHandler(this.FormRegistro_Load);
            this.gboxRopa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProNombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProTipoDonacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProTalla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProEdad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProSexo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.ComboBox cboxTipo;
        private System.Windows.Forms.GroupBox gboxRopa;
        private System.Windows.Forms.ComboBox cboxSexo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboxEdad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboxTalla;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btRegistrar;
        private System.Windows.Forms.Button btConsultarDonaciones;
        private System.Windows.Forms.ErrorProvider errorProNombre;
        private System.Windows.Forms.ErrorProvider errorProDescripcion;
        private System.Windows.Forms.ErrorProvider errorProCantidad;
        private System.Windows.Forms.ErrorProvider errorProTipoDonacion;
        private System.Windows.Forms.ErrorProvider errorProTalla;
        private System.Windows.Forms.ErrorProvider errorProEdad;
        private System.Windows.Forms.ErrorProvider errorProSexo;
    }
}