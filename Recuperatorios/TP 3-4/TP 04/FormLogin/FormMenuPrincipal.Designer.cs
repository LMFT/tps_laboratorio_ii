namespace Formularios
{
    partial class FormMenuPrincipal
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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnAgregarPedido = new System.Windows.Forms.Button();
            this.btnCerrarMesa = new System.Windows.Forms.Button();
            this.btnInfoEmpleados = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.rtxtInfoMesa = new System.Windows.Forms.RichTextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lstMesas = new System.Windows.Forms.ListBox();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.lblListadoMesas = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblUsuario.Location = new System.Drawing.Point(12, 9);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(123, 21);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Saludos, usuario";
            // 
            // btnAsignar
            // 
            this.btnAsignar.BackColor = System.Drawing.Color.Moccasin;
            this.btnAsignar.Location = new System.Drawing.Point(12, 139);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(372, 23);
            this.btnAsignar.TabIndex = 3;
            this.btnAsignar.Text = "Asignar mesa";
            this.btnAsignar.UseVisualStyleBackColor = false;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnAgregarPedido
            // 
            this.btnAgregarPedido.BackColor = System.Drawing.Color.Moccasin;
            this.btnAgregarPedido.Location = new System.Drawing.Point(12, 168);
            this.btnAgregarPedido.Name = "btnAgregarPedido";
            this.btnAgregarPedido.Size = new System.Drawing.Size(372, 23);
            this.btnAgregarPedido.TabIndex = 4;
            this.btnAgregarPedido.Text = "Agregar pedido";
            this.btnAgregarPedido.UseVisualStyleBackColor = false;
            this.btnAgregarPedido.Click += new System.EventHandler(this.btnAgregarPedido_Click);
            // 
            // btnCerrarMesa
            // 
            this.btnCerrarMesa.BackColor = System.Drawing.Color.Moccasin;
            this.btnCerrarMesa.Location = new System.Drawing.Point(12, 199);
            this.btnCerrarMesa.Name = "btnCerrarMesa";
            this.btnCerrarMesa.Size = new System.Drawing.Size(372, 23);
            this.btnCerrarMesa.TabIndex = 5;
            this.btnCerrarMesa.Text = "Cerrar mesa";
            this.btnCerrarMesa.UseVisualStyleBackColor = false;
            this.btnCerrarMesa.Click += new System.EventHandler(this.btnCerrarMesa_Click);
            // 
            // btnInfoEmpleados
            // 
            this.btnInfoEmpleados.BackColor = System.Drawing.Color.Moccasin;
            this.btnInfoEmpleados.Location = new System.Drawing.Point(12, 286);
            this.btnInfoEmpleados.Name = "btnInfoEmpleados";
            this.btnInfoEmpleados.Size = new System.Drawing.Size(372, 23);
            this.btnInfoEmpleados.TabIndex = 6;
            this.btnInfoEmpleados.Text = "Informacion Empleados";
            this.btnInfoEmpleados.UseVisualStyleBackColor = false;
            this.btnInfoEmpleados.Click += new System.EventHandler(this.btnInfoEmpleados_Click);
            // 
            // btnStock
            // 
            this.btnStock.BackColor = System.Drawing.Color.Moccasin;
            this.btnStock.Location = new System.Drawing.Point(12, 228);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(372, 23);
            this.btnStock.TabIndex = 8;
            this.btnStock.Text = "Stock";
            this.btnStock.UseVisualStyleBackColor = false;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // rtxtInfoMesa
            // 
            this.rtxtInfoMesa.BackColor = System.Drawing.Color.NavajoWhite;
            this.rtxtInfoMesa.Location = new System.Drawing.Point(12, 37);
            this.rtxtInfoMesa.Name = "rtxtInfoMesa";
            this.rtxtInfoMesa.ReadOnly = true;
            this.rtxtInfoMesa.Size = new System.Drawing.Size(372, 96);
            this.rtxtInfoMesa.TabIndex = 10;
            this.rtxtInfoMesa.Text = "Aca iría la info de la mesa seleccionada";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Moccasin;
            this.btnSalir.Location = new System.Drawing.Point(220, 315);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(164, 23);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lstMesas
            // 
            this.lstMesas.BackColor = System.Drawing.Color.NavajoWhite;
            this.lstMesas.FormattingEnabled = true;
            this.lstMesas.ItemHeight = 15;
            this.lstMesas.Location = new System.Drawing.Point(403, 37);
            this.lstMesas.Name = "lstMesas";
            this.lstMesas.Size = new System.Drawing.Size(385, 304);
            this.lstMesas.TabIndex = 12;
            this.lstMesas.SelectedIndexChanged += new System.EventHandler(this.lstMesas_SelectedIndexChanged);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Moccasin;
            this.btnCerrarSesion.Location = new System.Drawing.Point(12, 315);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(173, 23);
            this.btnCerrarSesion.TabIndex = 13;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // lblListadoMesas
            // 
            this.lblListadoMesas.AutoSize = true;
            this.lblListadoMesas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblListadoMesas.Location = new System.Drawing.Point(403, 9);
            this.lblListadoMesas.Name = "lblListadoMesas";
            this.lblListadoMesas.Size = new System.Drawing.Size(127, 21);
            this.lblListadoMesas.TabIndex = 14;
            this.lblListadoMesas.Text = "Listado de mesas";
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.Moccasin;
            this.btnMenu.Location = new System.Drawing.Point(12, 257);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(372, 23);
            this.btnMenu.TabIndex = 15;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(800, 343);
            this.ControlBox = false;
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.lblListadoMesas);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.lstMesas);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.rtxtInfoMesa);
            this.Controls.Add(this.btnStock);
            this.Controls.Add(this.btnInfoEmpleados);
            this.Controls.Add(this.btnCerrarMesa);
            this.Controls.Add(this.btnAgregarPedido);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.lblUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMenuPrincipal";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMenuPrincipal_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnAgregarPedido;
        private System.Windows.Forms.Button btnCerrarMesa;
        private System.Windows.Forms.Button btnInfoEmpleados;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.RichTextBox rtxtInfoMesa;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ListBox lstMesas;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label lblListadoMesas;
        private System.Windows.Forms.Button btnMenu;
    }
}