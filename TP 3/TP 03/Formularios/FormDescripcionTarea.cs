using System;
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
    public partial class FormDescripcionTarea : Form
    {
        private string descripcion;

        public string Descripcion
        {
            get
            {
                return descripcion;
            }
        }
        public FormDescripcionTarea()
        {
            descripcion = "";
            InitializeComponent();
        }

        public FormDescripcionTarea(string descripcion)
        {
            this.descripcion = descripcion;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            descripcion = rtxtDescripcion.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
