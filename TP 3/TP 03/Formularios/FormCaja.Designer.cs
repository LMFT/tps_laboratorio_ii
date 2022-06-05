namespace Formularios
{
    partial class FormCaja
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
            this.rtxtListaProductos = new System.Windows.Forms.RichTextBox();
            this.grpMetodoPago = new System.Windows.Forms.GroupBox();
            this.lblCuotas = new System.Windows.Forms.Label();
            this.nudCuotas = new System.Windows.Forms.NumericUpDown();
            this.rdoDebito = new System.Windows.Forms.RadioButton();
            this.rdoCredito = new System.Windows.Forms.RadioButton();
            this.rdoEfectivo = new System.Windows.Forms.RadioButton();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpMetodoPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCuotas)).BeginInit();
            this.SuspendLayout();
            // 
            // rtxtListaProductos
            // 
            this.rtxtListaProductos.BackColor = System.Drawing.Color.NavajoWhite;
            this.rtxtListaProductos.Location = new System.Drawing.Point(12, 12);
            this.rtxtListaProductos.Name = "rtxtListaProductos";
            this.rtxtListaProductos.Size = new System.Drawing.Size(201, 279);
            this.rtxtListaProductos.TabIndex = 0;
            this.rtxtListaProductos.Text = "Informacion de los productos";
            // 
            // grpMetodoPago
            // 
            this.grpMetodoPago.Controls.Add(this.lblCuotas);
            this.grpMetodoPago.Controls.Add(this.nudCuotas);
            this.grpMetodoPago.Controls.Add(this.rdoDebito);
            this.grpMetodoPago.Controls.Add(this.rdoCredito);
            this.grpMetodoPago.Controls.Add(this.rdoEfectivo);
            this.grpMetodoPago.Location = new System.Drawing.Point(233, 97);
            this.grpMetodoPago.Name = "grpMetodoPago";
            this.grpMetodoPago.Size = new System.Drawing.Size(234, 100);
            this.grpMetodoPago.TabIndex = 1;
            this.grpMetodoPago.TabStop = false;
            this.grpMetodoPago.Text = "Metodos de pago";
            // 
            // lblCuotas
            // 
            this.lblCuotas.AutoSize = true;
            this.lblCuotas.Location = new System.Drawing.Point(145, 40);
            this.lblCuotas.Name = "lblCuotas";
            this.lblCuotas.Size = new System.Drawing.Size(44, 15);
            this.lblCuotas.TabIndex = 4;
            this.lblCuotas.Text = "Cuotas";
            // 
            // nudCuotas
            // 
            this.nudCuotas.Location = new System.Drawing.Point(145, 58);
            this.nudCuotas.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nudCuotas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCuotas.Name = "nudCuotas";
            this.nudCuotas.Size = new System.Drawing.Size(58, 23);
            this.nudCuotas.TabIndex = 3;
            this.nudCuotas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rdoDebito
            // 
            this.rdoDebito.AutoSize = true;
            this.rdoDebito.Location = new System.Drawing.Point(15, 75);
            this.rdoDebito.Name = "rdoDebito";
            this.rdoDebito.Size = new System.Drawing.Size(97, 19);
            this.rdoDebito.TabIndex = 2;
            this.rdoDebito.Tag = "0";
            this.rdoDebito.Text = "Tarjeta Debito";
            this.rdoDebito.UseVisualStyleBackColor = true;
            this.rdoDebito.CheckedChanged += new System.EventHandler(this.MetodoPago_CheckedChanged);
            // 
            // rdoCredito
            // 
            this.rdoCredito.AutoSize = true;
            this.rdoCredito.Location = new System.Drawing.Point(15, 47);
            this.rdoCredito.Name = "rdoCredito";
            this.rdoCredito.Size = new System.Drawing.Size(101, 19);
            this.rdoCredito.TabIndex = 1;
            this.rdoCredito.Tag = "1";
            this.rdoCredito.Text = "Tarjeta Credito";
            this.rdoCredito.UseVisualStyleBackColor = true;
            this.rdoCredito.CheckedChanged += new System.EventHandler(this.MetodoPago_CheckedChanged);
            // 
            // rdoEfectivo
            // 
            this.rdoEfectivo.AutoSize = true;
            this.rdoEfectivo.Checked = true;
            this.rdoEfectivo.Location = new System.Drawing.Point(15, 22);
            this.rdoEfectivo.Name = "rdoEfectivo";
            this.rdoEfectivo.Size = new System.Drawing.Size(67, 19);
            this.rdoEfectivo.TabIndex = 0;
            this.rdoEfectivo.TabStop = true;
            this.rdoEfectivo.Tag = "0";
            this.rdoEfectivo.Text = "Efectivo";
            this.rdoEfectivo.UseVisualStyleBackColor = true;
            this.rdoEfectivo.CheckedChanged += new System.EventHandler(this.MetodoPago_CheckedChanged);
            // 
            // btnCobrar
            // 
            this.btnCobrar.Location = new System.Drawing.Point(219, 270);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(105, 23);
            this.btnCobrar.TabIndex = 2;
            this.btnCobrar.Text = "Cobrar";
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(362, 268);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(476, 305);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.grpMetodoPago);
            this.Controls.Add(this.rtxtListaProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormCaja";
            this.Text = "Cobrar";
            this.Load += new System.EventHandler(this.FormCaja_Load);
            this.grpMetodoPago.ResumeLayout(false);
            this.grpMetodoPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCuotas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtListaProductos;
        private System.Windows.Forms.GroupBox grpMetodoPago;
        private System.Windows.Forms.RadioButton rdoDebito;
        private System.Windows.Forms.RadioButton rdoCredito;
        private System.Windows.Forms.RadioButton rdoEfectivo;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblCuotas;
        private System.Windows.Forms.NumericUpDown nudCuotas;
    }
}