﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormAutoCompletar : Form
    {
        public FormAutoCompletar()
        {
            InitializeComponent();
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.Yes;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
