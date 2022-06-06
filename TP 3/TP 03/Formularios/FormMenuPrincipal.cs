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
            lstTareas.DataSource = ControladorMenuPrincipal.Tareas;
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

        private void ActualizarInterfaz()
        {
            lstTareas.DataSource = null;
            lstTareas.DataSource = ControladorMenuPrincipal.Tareas;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            try
            {
                FolderBrowserDialog browser = new FolderBrowserDialog();
                browser.Description = "Seleccione la carpeta en donde desea almacenar los archivos";
                if (browser.ShowDialog() == DialogResult.OK)
                {
                    string ruta = browser.SelectedPath;
                    if (ruta is not null)
                    {
                        ControladorMenuPrincipal.Guardar(ruta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            Mostrar(MostrarInfo.Inventario);
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
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Mostrar(MostrarInfo.Proveedores);
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
            string mensaje = "Esta seguro que desea salir? Se perderán los cambios no guardados";
            string titulo = "Salir";
            MessageBoxButtons botones = MessageBoxButtons.YesNo;
            MessageBoxIcon icono = MessageBoxIcon.Question;
            if(MessageBox.Show(mensaje, titulo, botones, icono) == DialogResult.No) 
            {
                e.Cancel = true;
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        //A implementar para TP 4
        private void CargarDesde()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Seleccione la carpeta desde la cual cargar los archivos";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                //ControladorMenuPrincipal.Cargar(folderBrowserDialog.SelectedPath);
            }
        }
        private void Cargar()
        {
            try
            {
                ControladorMenuPrincipal.Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            FormAgregar frm = new FormAgregar(true);
            
            if(frm.ShowDialog() == DialogResult.OK)
            {
                FormCaja formCaja = new FormCaja();
                formCaja.ShowDialog();
            }
        }

        private void btnNuevaTarea_Click(object sender, EventArgs e)
        {
            NuevaTarea();
            ActualizarInterfaz();
        }

        private void NuevaTarea()
        {
            FormDescripcionTarea frm = new FormDescripcionTarea();
            if(frm.ShowDialog() == DialogResult.OK && frm.Descripcion != "")
            {
                ControladorMenuPrincipal.NuevaTarea(frm.Descripcion);
            }
        }

        private void btnEliminarTarea_Click(object sender, EventArgs e)
        {
            EliminarTarea();
            ActualizarInterfaz();
        }

        private void EliminarTarea()
        {
            try
            {
                ControladorMenuPrincipal.EliminarTarea(lstTareas.SelectedItem);
                ActualizarInterfaz();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarTarea_Click(object sender, EventArgs e)
        {
            EditarTarea();
            ActualizarInterfaz();
        }

        private void EditarTarea()
        {
            try
            {
                FormDescripcionTarea frm = new FormDescripcionTarea(lstTareas.Text);
                if (frm.ShowDialog() == DialogResult.OK && frm.Descripcion != "")
                {
                    ControladorMenuPrincipal.EditarTarea(lstTareas.SelectedIndex, frm.Descripcion);
                }
                ActualizarInterfaz();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
