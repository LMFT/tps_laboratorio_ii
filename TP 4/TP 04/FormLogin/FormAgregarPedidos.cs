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
        private bool cargaPedido;
        //El constructor sin parametros es utilizado para agregar ingredientes
        public FormAgregar()
        {
            InitializeComponent();
            CambiarColor();
            cargaPedido = false;
            Text = "Agregar ingredientes";
        }

        //El constructor parametrizado es utilizado para agregar pedidos
        public FormAgregar(int indiceMesa) : this()
        {
            cargaPedido = true;
            Text = "Agregar pedidos";
            ControladorAgregar.SetMesa(indiceMesa);
            ControladorAgregar.LimpiarPedidos();
            ControladorAgregar.LimpiarIngredientes();
            ActualizarInterfaz();
        }
        /// <summary>
        /// Cambia el color de la aplicacion en base a los permisos del usuario logueado
        /// </summary>
        private void CambiarColor()
        {
            if (!ControladorAgregar.UsuarioEsAdmin)
            {
                BackColor = Color.LightSkyBlue;
                lstAgregados.BackColor = Color.LightBlue;
                lstExistencias.BackColor = Color.LightBlue;
                nudCantidad.BackColor = Color.LightBlue;
                foreach (Control control in Controls.OfType<Button>())
                {
                    control.BackColor = Color.PowderBlue;
                }
            }
            else
            {
                BackColor = Color.Tan;
                lstAgregados.BackColor = Color.NavajoWhite;
                lstExistencias.BackColor = Color.NavajoWhite;
                nudCantidad.BackColor = Color.NavajoWhite;
                foreach (Control control in Controls.OfType<Button>())
                {
                    control.BackColor = Color.Moccasin;
                }
            }
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
            if (cargaPedido)
            {
                ControladorAgregar.EliminarPedido(lstAgregados.SelectedIndex, (int)nudCantidad.Value);
            }
            else
            {
                ControladorAgregar.EliminarIngrediente(lstAgregados.SelectedIndex, (double)nudCantidad.Value);
            }
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
            bool resultado;
            if (cargaPedido)
            {
                resultado = ControladorAgregar.AgregarPedido(lstExistencias.SelectedIndex, (int)nudCantidad.Value);
            }
            else
            {
                resultado = ControladorAgregar.AgregarIngrediente(lstExistencias.SelectedIndex, (double)nudCantidad.Value);
            }
            if (!resultado)
            {
                string mensaje = "Error: Este producto no puede prepararse por falta de ingredientes";
                string titulo = "Error";
                MessageBoxButtons boton = MessageBoxButtons.OK;
                MessageBoxIcon icono = MessageBoxIcon.Error;
                MessageBox.Show(mensaje, titulo, boton, icono);
            }
        }
        /// <summary>
        /// Actualiza la interfaz gráfica luego de realizarse un cambio
        /// </summary>
        private void ActualizarInterfaz()
        {
            if(cargaPedido)
            {
                lstExistencias.DataSource = null;
                lstExistencias.DataSource = ControladorAgregar.Menu;
                lstAgregados.DataSource = null;
                lstAgregados.DataSource = ControladorAgregar.Pedidos;
                nudCantidad.Value = 1;
            }
            else
            {

                lstExistencias.DataSource = null;
                lstExistencias.DataSource = ControladorAgregar.Inventario;
                lstAgregados.DataSource = null;
                lstAgregados.DataSource = ControladorAgregar.Ingredientes;
                nudCantidad.Value = 1;
            }
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
