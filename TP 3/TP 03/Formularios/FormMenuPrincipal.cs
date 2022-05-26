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
    public partial class FormMenuPrincipal : Form
    {
        private int nivelPermisos;
        private FormMenuPrincipal()
        {
            InitializeComponent();
        }

        public FormMenuPrincipal(int nivelPermisos)
        {
            this.nivelPermisos = nivelPermisos;
        }

    }
}
