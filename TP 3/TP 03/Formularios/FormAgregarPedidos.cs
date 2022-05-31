using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Logica.AgregarPedidos;

using Mostrar;

namespace Formularios
{
    public partial class FormAgregar : Form
    {

        public FormAgregar()
        {
        }

        public FormAgregar(int indiceMesa) : this()
        {
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            ActualizarInterfaz();
        }
        /// <summary>
        /// Elimina el elemento seleccionado de la lista
        /// </summary>
        private void Eliminar()
        {

        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
            ActualizarInterfaz();
        }
        /// <summary>
        /// Añade el elemento seleccionado a la lista
        /// </summary>
        private void Agregar()
        {
        }
        /// <summary>
        /// Actualiza la interfaz gráfica luego de realizarse un cambio
        /// </summary>
        private void ActualizarInterfaz()
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
