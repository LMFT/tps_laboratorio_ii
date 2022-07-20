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
        private List<Task> tareas;
        public FormMenuPrincipal()
        {
            InitializeComponent();
            lblUsuario.Text = $"Hola, {ControladorMenuPrincipal.UsuarioLogeado}!";
            lstTareas.DataSource = ControladorMenuPrincipal.Tareas;
            OcultarControles();
            tareas = new List<Task>();
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportar();
        }

        private void Exportar()
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
                        ControladorMenuPrincipal.Exportar(ruta);
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

        private void btnImportar_Click(object sender, EventArgs e)
        {
            Importar();
        }

        private void Importar()
        {
            try
            {
                ControladorMenuPrincipal.Importar();
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
                if(lstTareas.SelectedIndex == -1)
                {
                    throw new NullReferenceException("No hay ningun item seleccionado");
                }
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Task tarea = new Task(Guardar);
            tarea.Start();
            tareas.Add(tarea);
        }

        private void Guardar()
        {
            try
            {
                ControladorMenuPrincipal.Guardar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            Task tarea = new Task(Cargar);
            tarea.Start();
            tareas.Add(tarea);
        }

        private void Cargar()
        {
            try
            {
                ControladorMenuPrincipal.Cargar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
