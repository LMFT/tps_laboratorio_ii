
namespace WinFormsApp1
{
    partial class FormCalculadora
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txbSegundoOperador = new System.Windows.Forms.TextBox();
            this.txbPrimerOperador = new System.Windows.Forms.TextBox();
            this.btnOperar = new System.Windows.Forms.Button();
            this.cbxOperacion = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnBinarioADecimal = new System.Windows.Forms.Button();
            this.btnDecimalABinario = new System.Windows.Forms.Button();
            this.lblPrimerOperacion = new System.Windows.Forms.Label();
            this.lblOperacion = new System.Windows.Forms.Label();
            this.lblSegundoOperador = new System.Windows.Forms.Label();
            this.lstOperaciones = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txbSegundoOperador
            // 
            this.txbSegundoOperador.BackColor = System.Drawing.Color.PapayaWhip;
            this.txbSegundoOperador.Location = new System.Drawing.Point(305, 41);
            this.txbSegundoOperador.Name = "txbSegundoOperador";
            this.txbSegundoOperador.Size = new System.Drawing.Size(100, 23);
            this.txbSegundoOperador.TabIndex = 2;
            // 
            // txbPrimerOperador
            // 
            this.txbPrimerOperador.BackColor = System.Drawing.Color.PapayaWhip;
            this.txbPrimerOperador.Location = new System.Drawing.Point(23, 41);
            this.txbPrimerOperador.Name = "txbPrimerOperador";
            this.txbPrimerOperador.Size = new System.Drawing.Size(100, 23);
            this.txbPrimerOperador.TabIndex = 0;
            // 
            // btnOperar
            // 
            this.btnOperar.Location = new System.Drawing.Point(23, 112);
            this.btnOperar.Name = "btnOperar";
            this.btnOperar.Size = new System.Drawing.Size(111, 31);
            this.btnOperar.TabIndex = 4;
            this.btnOperar.Text = "Operar";
            this.btnOperar.UseVisualStyleBackColor = true;
            this.btnOperar.Click += new System.EventHandler(this.btnOperar_Click);
            // 
            // cbxOperacion
            // 
            this.cbxOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxOperacion.FormattingEnabled = true;
            this.cbxOperacion.Items.AddRange(new object[] {
            " ",
            "+",
            "-",
            "*",
            "/"});
            this.cbxOperacion.Location = new System.Drawing.Point(178, 41);
            this.cbxOperacion.Name = "cbxOperacion";
            this.cbxOperacion.Size = new System.Drawing.Size(77, 23);
            this.cbxOperacion.TabIndex = 1;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(167, 112);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(111, 31);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(294, 112);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(111, 31);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnBinarioADecimal
            // 
            this.btnBinarioADecimal.Location = new System.Drawing.Point(37, 162);
            this.btnBinarioADecimal.Name = "btnBinarioADecimal";
            this.btnBinarioADecimal.Size = new System.Drawing.Size(179, 31);
            this.btnBinarioADecimal.TabIndex = 7;
            this.btnBinarioADecimal.Text = "Convertir a Decimal";
            this.btnBinarioADecimal.UseVisualStyleBackColor = true;
            this.btnBinarioADecimal.Click += new System.EventHandler(this.btnBinarioADecimal_Click);
            // 
            // btnDecimalABinario
            // 
            this.btnDecimalABinario.Location = new System.Drawing.Point(242, 162);
            this.btnDecimalABinario.Name = "btnDecimalABinario";
            this.btnDecimalABinario.Size = new System.Drawing.Size(149, 31);
            this.btnDecimalABinario.TabIndex = 8;
            this.btnDecimalABinario.Text = "Convertir a Binario";
            this.btnDecimalABinario.UseVisualStyleBackColor = true;
            this.btnDecimalABinario.Click += new System.EventHandler(this.btnDecimalABinario_Click);
            // 
            // lblPrimerOperacion
            // 
            this.lblPrimerOperacion.AutoSize = true;
            this.lblPrimerOperacion.Location = new System.Drawing.Point(23, 23);
            this.lblPrimerOperacion.Name = "lblPrimerOperacion";
            this.lblPrimerOperacion.Size = new System.Drawing.Size(93, 15);
            this.lblPrimerOperacion.TabIndex = 9;
            this.lblPrimerOperacion.Text = "Primer operador";
            // 
            // lblOperacion
            // 
            this.lblOperacion.AutoSize = true;
            this.lblOperacion.Location = new System.Drawing.Point(178, 23);
            this.lblOperacion.Name = "lblOperacion";
            this.lblOperacion.Size = new System.Drawing.Size(62, 15);
            this.lblOperacion.TabIndex = 10;
            this.lblOperacion.Text = "Operacion";
            // 
            // lblSegundoOperador
            // 
            this.lblSegundoOperador.AutoSize = true;
            this.lblSegundoOperador.Location = new System.Drawing.Point(305, 23);
            this.lblSegundoOperador.Name = "lblSegundoOperador";
            this.lblSegundoOperador.Size = new System.Drawing.Size(105, 15);
            this.lblSegundoOperador.TabIndex = 11;
            this.lblSegundoOperador.Text = "Segundo operador";
            // 
            // lstOperaciones
            // 
            this.lstOperaciones.BackColor = System.Drawing.Color.PapayaWhip;
            this.lstOperaciones.FormattingEnabled = true;
            this.lstOperaciones.ItemHeight = 15;
            this.lstOperaciones.Location = new System.Drawing.Point(416, 12);
            this.lstOperaciones.Name = "lstOperaciones";
            this.lstOperaciones.Size = new System.Drawing.Size(225, 184);
            this.lstOperaciones.TabIndex = 3;
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(653, 201);
            this.Controls.Add(this.lstOperaciones);
            this.Controls.Add(this.lblSegundoOperador);
            this.Controls.Add(this.lblOperacion);
            this.Controls.Add(this.lblPrimerOperacion);
            this.Controls.Add(this.btnDecimalABinario);
            this.Controls.Add(this.btnBinarioADecimal);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.cbxOperacion);
            this.Controls.Add(this.btnOperar);
            this.Controls.Add(this.txbPrimerOperador);
            this.Controls.Add(this.txbSegundoOperador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de Lucas Ferrini 2ºD";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCalculadora_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbSegundoOperador;
        private System.Windows.Forms.TextBox txbPrimerOperador;
        private System.Windows.Forms.Button btnOperar;
        private System.Windows.Forms.ComboBox cbxOperacion;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnBinarioADecimal;
        private System.Windows.Forms.Button btnDecimalABinario;
        private System.Windows.Forms.Label lblPrimerOperacion;
        private System.Windows.Forms.Label lblOperacion;
        private System.Windows.Forms.Label lblSegundoOperador;
        private System.Windows.Forms.ListBox lstOperaciones;
    }
}

