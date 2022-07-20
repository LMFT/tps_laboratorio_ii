namespace Formularios
{
    partial class FormRellenar
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
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.nudCantidadMinima = new System.Windows.Forms.NumericUpDown();
            this.btnAutoRellenar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadMinima)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(32, 9);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(272, 15);
            this.lblCantidad.TabIndex = 0;
            this.lblCantidad.Text = "Ingrese la cantidad de unidades que desea agregar";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(10, 92);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(106, 30);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // nudCantidadMinima
            // 
            this.nudCantidadMinima.Location = new System.Drawing.Point(108, 41);
            this.nudCantidadMinima.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidadMinima.Name = "nudCantidadMinima";
            this.nudCantidadMinima.Size = new System.Drawing.Size(120, 23);
            this.nudCantidadMinima.TabIndex = 3;
            this.nudCantidadMinima.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAutoRellenar
            // 
            this.btnAutoRellenar.Location = new System.Drawing.Point(122, 92);
            this.btnAutoRellenar.Name = "btnAutoRellenar";
            this.btnAutoRellenar.Size = new System.Drawing.Size(106, 30);
            this.btnAutoRellenar.TabIndex = 4;
            this.btnAutoRellenar.Text = "Auto rellenar";
            this.btnAutoRellenar.UseVisualStyleBackColor = true;
            this.btnAutoRellenar.Click += new System.EventHandler(this.btnAutoRellenar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(236, 92);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(106, 30);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormRellenar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(356, 130);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAutoRellenar);
            this.Controls.Add(this.nudCantidadMinima);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblCantidad);
            this.Name = "FormRellenar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rellenar Stock";
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadMinima)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.NumericUpDown nudCantidadMinima;
        private System.Windows.Forms.Button btnAutoRellenar;
        private System.Windows.Forms.Button btnCancelar;
    }
}