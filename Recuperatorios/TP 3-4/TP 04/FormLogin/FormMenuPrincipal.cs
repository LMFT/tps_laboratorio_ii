using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Logica.MenuPrincipal;

using Mostrar;

namespace Formularios
{
    public partial class FormMenuPrincipal : Form
    { 
        public FormMenuPrincipal()
        {
            InitializeComponent();
            lblUsuario.Text = $"Hola, {ControladorMenuPrincipal.UsuarioLogeado}!";
            CambiarColor();
            OcultarControles();
            lstMesas.DataSource = ControladorMenuPrincipal.Mesas;
        }
        /// <summary>
        /// Cambia el color de la aplicacion en base a los permisos del usuario logueado
        /// </summary>
        private void CambiarColor()
        {
            if (!ControladorMenuPrincipal.UsuarioEsAdmin)
            {
                BackColor = Color.LightSkyBlue;
                lstMesas.BackColor = Color.LightBlue;
                rtxtInfoMesa.BackColor = Color.LightBlue;
                foreach (Control control in Controls.OfType<Button>())
                {
                    control.BackColor = Color.PowderBlue;
                }
            }
            else
            {
                BackColor = Color.Tan;
                lstMesas.BackColor = Color.NavajoWhite;
                rtxtInfoMesa.BackColor = Color.NavajoWhite;
                foreach (Control control in Controls.OfType<Button>())
                {
                    control.BackColor = Color.Moccasin;
                }
            }
        }
        /// <summary>
        /// Oculta controles segun el nivel de permisos del usuario logueado
        /// </summary>
        private void OcultarControles()
        {
            if (!ControladorMenuPrincipal.UsuarioEsAdmin)
            {
                btnInfoEmpleados.Hide();
            }
        }
        /// <summary>
        /// Actualiza la interfaz
        /// </summary>
        private void ActualizarInterfaz()
        {
            lstMesas.DataSource = null;
            lstMesas.DataSource = ControladorMenuPrincipal.Mesas;
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            AsignarMesa();
            ActualizarInterfaz();
        }
        /// <summary>
        /// Intenta asignar una mesa, ocupándola si esta libre o informando de que la misma se encuentra
        /// ocupada
        /// </summary>
        private void AsignarMesa()
        {
            MessageBoxButtons boton = MessageBoxButtons.OK;
            MessageBoxIcon icono = MessageBoxIcon.Error;
            string mensaje;
            string titulo = "Error";
            switch(ControladorMenuPrincipal.AsignarMesa(lstMesas.SelectedIndex, IncluirEstacionamiento()))
            {
                case 0:
                    mensaje = "Mesa asignada exitosamente";
                    titulo = "Exito";
                    icono = MessageBoxIcon.Information;
                    break;
                case 1:
                    mensaje = "Error: Esta mesa ya está ocupada";
                    break;
                default:
                    mensaje = "Error: No se encuentra esta mesa";
                    break;

            }
            MessageBox.Show(mensaje, titulo, boton, icono);
        }
        /// <summary>
        /// Pregunta al usuario si se deberia incluir el estacionamiento en la mesa seleccionada
        /// </summary>
        /// <returns></returns>
        private bool IncluirEstacionamiento()
        {
            MessageBoxButtons botones = MessageBoxButtons.YesNo;
            MessageBoxIcon icono = MessageBoxIcon.Question;
            string mensaje = "Desea incluir el costo de estacionamiento?";
            string titulo = "Incluir estacionamiento";
            DialogResult resultado = MessageBox.Show(mensaje, titulo, botones, icono);
            return resultado == DialogResult.Yes;
        }

        private void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            AgregarPedido();
        }
        /// <summary>
        /// Abre la ventana para agregar pedidos. Si se confirman los pedidos en esa ventana, los
        /// mismos son agregados a la mesa seleccionada
        /// </summary>
        private void AgregarPedido()
        {
            if (!ControladorMenuPrincipal.MesaLibre(lstMesas.SelectedIndex))
            {
                FormAgregar frm = new FormAgregar(lstMesas.SelectedIndex);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    ControladorMenuPrincipal.AgregarPedidos(lstMesas.SelectedIndex);
                }
            }
            else
            {
                MessageBoxButtons boton = MessageBoxButtons.OK;
                MessageBoxIcon icono = MessageBoxIcon.Error;
                string mensaje = "La mesa se encuentra libre, no se puede asignar el pedido";
                string titulo = "Error";
                MessageBox.Show(mensaje, titulo, boton, icono);
            }
        }
        
        private void btnCerrarMesa_Click(object sender, EventArgs e)
        {
            CerrarMesa();
            ActualizarInterfaz();
        }
        /// <summary>
        /// Cierra la mesa, abriendo la ventana de pagos y permitiendo realizar el cobro
        /// </summary>
        private void CerrarMesa()
        {
            if (!ControladorMenuPrincipal.MesaLibre(lstMesas.SelectedIndex))
            {
                FormCaja formCaja = new FormCaja(lstMesas.SelectedIndex);
                formCaja.ShowDialog();
            }
            else
            {
                MessageBoxIcon icono = MessageBoxIcon.Error;
                MessageBoxButtons boton = MessageBoxButtons.OK;
                string mensaje = $"La mesa esta libre, no puede cerrarse";
                string titulo = "Error";
                MessageBox.Show(mensaje, titulo, boton, icono);
            }
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            Mostrar(MostrarInfo.Inventario);
            ActualizarInterfaz();
        }
        /// <summary>
        /// Abre la ventana para mostrar informacion
        /// </summary>
        /// <param name="mostrarInfo">Tipo de informacion a mostrar. Pueden ser empleados, elementos del menu
        /// o elementos del stock</param>
        private void Mostrar(MostrarInfo mostrarInfo)
        {
            FormMostrar frm = new FormMostrar(mostrarInfo);
            frm.ShowDialog();
        }

        private void btnInfoEmpleados_Click(object sender, EventArgs e)
        {
            Mostrar(MostrarInfo.Empleado);
            ActualizarInterfaz();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Mostrar(MostrarInfo.Menu);
            ActualizarInterfaz();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }
        /// <summary>
        /// Cierra la sesion del usuario actual, permitiendo logear a otra persona
        /// </summary>
        private void CerrarSesion()
        {
            DialogResult = DialogResult.No;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            string mensaje = "Esta seguro que desea salir?";
            string titulo = "Salir";
            MessageBoxButtons botones = MessageBoxButtons.YesNo;
            MessageBoxIcon icono = MessageBoxIcon.Question;
            if(MessageBox.Show(mensaje, titulo, botones, icono) == DialogResult.No) 
            {
                e.Cancel = true;
            }
        }

        private void lstMesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtxtInfoMesa.Text = ControladorMenuPrincipal.MostrarMesa(lstMesas.SelectedIndex);
        }
    }
}
