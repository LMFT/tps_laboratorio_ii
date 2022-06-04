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
            OcultarControles();
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

        private void BtnNuevaVenta_Click(object sender, EventArgs e)
        {
            FormAgregar frm = new FormAgregar(true);
            frm.ShowDialog();
            ActualizarInterfaz();
        }

        private void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            ActualizarInterfaz();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
            ActualizarInterfaz();
        }

        private void Guardar()
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            if (browser.ShowDialog() == DialogResult.OK)
            {
                string ruta = browser.SelectedPath;
                if (ruta is not null)
                {
                    ControladorMenuPrincipal.Guardar(ruta);
                }
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
            Mostrar(MostrarInfo.Proveedores);
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
    }
}
