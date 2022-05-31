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

        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            ActualizarInterfaz();
        }

        private void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            ActualizarInterfaz();

        }

        private void btnCerrarMesa_Click(object sender, EventArgs e)
        {

            ActualizarInterfaz();
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

        }
    }
}
