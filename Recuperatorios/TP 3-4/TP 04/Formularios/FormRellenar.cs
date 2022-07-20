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
    public partial class FormRellenar : Form
    {
        private int cantidad;
        public FormRellenar()
        {
            InitializeComponent();
        }
        public int Cantidad
        {
            get
            {
                return cantidad;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            cantidad = (int)nudCantidadMinima.Value;
            //Utilizo la propiedad DialogResult como bandera para saber si auto rellenar stock
            //o añadir una cantidad determinada
            DialogResult = DialogResult.No;
        }

        private void btnAutoRellenar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
