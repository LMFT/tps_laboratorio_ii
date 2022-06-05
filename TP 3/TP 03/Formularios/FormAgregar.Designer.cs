namespace Formularios
{
    partial class FormAgregar
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
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.mesaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bebidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lstExistencias = new System.Windows.Forms.ListBox();
            this.lstAgregados = new System.Windows.Forms.ListBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mesaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bebidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.Moccasin;
            this.btnConfirmar.Location = new System.Drawing.Point(12, 368);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(208, 37);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Moccasin;
            this.btnCancelar.Location = new System.Drawing.Point(363, 368);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(208, 37);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lstExistencias
            // 
            this.lstExistencias.BackColor = System.Drawing.Color.NavajoWhite;
            this.lstExistencias.FormattingEnabled = true;
            this.lstExistencias.ItemHeight = 15;
            this.lstExistencias.Location = new System.Drawing.Point(12, 28);
            this.lstExistencias.Name = "lstExistencias";
            this.lstExistencias.Size = new System.Drawing.Size(208, 319);
            this.lstExistencias.TabIndex = 0;
            // 
            // lstAgregados
            // 
            this.lstAgregados.BackColor = System.Drawing.Color.NavajoWhite;
            this.lstAgregados.FormattingEnabled = true;
            this.lstAgregados.ItemHeight = 15;
            this.lstAgregados.Location = new System.Drawing.Point(363, 28);
            this.lstAgregados.Name = "lstAgregados";
            this.lstAgregados.Size = new System.Drawing.Size(208, 319);
            this.lstAgregados.TabIndex = 4;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Moccasin;
            this.btnAgregar.Location = new System.Drawing.Point(333, 158);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 26);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = ">";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Moccasin;
            this.btnEliminar.Location = new System.Drawing.Point(225, 158);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(25, 26);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "<";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Productos disponibles";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "A agregar";
            // 
            // nudCantidad
            // 
            this.nudCantidad.BackColor = System.Drawing.Color.NavajoWhite;
            this.nudCantidad.Location = new System.Drawing.Point(256, 158);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(71, 23);
            this.nudCantidad.TabIndex = 9;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(261, 140);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(55, 15);
            this.lblCantidad.TabIndex = 10;
            this.lblCantidad.Text = "Cantidad";
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(582, 408);
            this.ControlBox = false;
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lstAgregados);
            this.Controls.Add(this.lstExistencias);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMenu";
            this.Load += new System.EventHandler(this.FormVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mesaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bebidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.BindingSource mesaBindingSource;
        private System.Windows.Forms.BindingSource bebidaBindingSource;
        private System.Windows.Forms.BindingSource comidaBindingSource;
        private System.Windows.Forms.ListBox lstExistencias;
        private System.Windows.Forms.ListBox lstAgregados;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label lblCantidad;
    }
}