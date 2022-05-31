using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Mostrar;
using Logica.Mostrar;

namespace Formularios
{
    public partial class FormMostrar : Form
    {
        private MostrarInfo mostrarInfo;
        private FormMostrar()
        {
            InitializeComponent();
            CambiarColor();
        }

        public FormMostrar(MostrarInfo mostrar) : this()
        {
            mostrarInfo = mostrar;
            ConfigurarBotones();
            FormatearDataGrid();
            CambiarTitulo();
        }
        /// <summary>
        /// Cambia el color de la aplicacion en base a los permisos del usuario logueado
        /// </summary>
        private void CambiarColor()
        {
            if (!ControladorMostrar.UsuarioEsAdmin)
            {
                BackColor = Color.LightSkyBlue;
                dgvMostrar.BackColor = Color.LightBlue;
                foreach (Control control in Controls.OfType<Button>())
                {
                    control.BackColor = Color.PowderBlue;
                }
            }
            else
            {
                BackColor = Color.Tan;
                dgvMostrar.BackColor = Color.NavajoWhite;
                foreach (Control control in Controls.OfType<Button>())
                {
                    control.BackColor = Color.Moccasin;
                }
            }
        }

        /// <summary>
        /// Cambia el titulo del formulario segun el tipo de informacion a mostrar
        /// </summary>
        private void CambiarTitulo()
        {
            Text = mostrarInfo.ToString();
        }
        /// <summary>
        /// Da formato al datagrid segun el tipo de dato a mostrar
        /// </summary>
        private void FormatearDataGrid()
        {
            dgvMostrar.DataSource = null;
            switch (mostrarInfo)
            {
            
            }
        }
        /// <summary>
        /// Esconde los controles que no son necesarios, ya sea por el tipo de informacion
        /// a mostrar o por los permisos del usuario
        /// </summary>
        private void ConfigurarBotones()
        {
            if(mostrarInfo == MostrarInfo.Empleado)
            {
                btnRellenarNotificar.Hide();
            }
            if (!ControladorMostrar.UsuarioEsAdmin)
            {
                btnRemover.Hide();
                btnAgregar.Hide();
                btnRellenarNotificar.Text = "Notificar stock";
            }
            else
            {
                btnRellenarNotificar.Text = "Rellenar stock";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarElemento();
            FormatearDataGrid();
        }
        /// <summary>
        /// Rellena el stock del producto seleccionado a 2 veces su cantidad minima
        /// </summary>
        private void RellenarStock()
        {
            DataGridViewRow fila = SeleccionarFila();
            if(fila is not null)
            {
                ControladorMostrar.RellenarStock(fila.DataBoundItem);
            }
        }
        /// <summary>
        /// Añade la cantidad recibida al stock de un producto
        /// </summary>
        /// <param name="cantidad">Cantidad de unidades a agregar</param>
        private void RellenarStock(int cantidad)
        {
            DataGridViewRow fila = SeleccionarFila();
            if (fila is not null)
            {
                ControladorMostrar.RellenarStock(fila.DataBoundItem, cantidad);
            }
        }
        /// <summary>
        /// Notifica a un administrador / dueño del faltante de un producto
        /// </summary>
        private void NotificarFaltante()
        {
            DataGridViewRow fila = SeleccionarFila();
            if (fila is not null && ControladorMostrar.VerificarCantidad(fila.DataBoundItem))
            {
                string mensaje = "Se ha notificado al administrador de la falta de insumos";
                string titulo = "Notificacion enviada";
                MessageBoxButtons boton = MessageBoxButtons.OK;
                MessageBoxIcon icono = MessageBoxIcon.Information;
                MessageBox.Show(mensaje, titulo, boton, icono);
            }
        }
        /// <summary>
        /// Selecciona la primer fila que contenga una celda seleccionada
        /// </summary>
        /// <returns>Primer fila que contenga una celda seleccionada. En caso de no haber
        /// ninguna retorna null</returns>
        private DataGridViewRow SeleccionarFila()
        {
            foreach(DataGridViewRow fila in dgvMostrar.Rows)
            {
                if (FilaContieneCeldaSeleccionada(fila))
                {
                    return fila;
                }
            }
            return null;
        }
        /// <summary>
        /// Abre el formulario de ABM de elementos para dar de alta un producto
        /// </summary>
        private void AgregarElemento()
        {
            FormABM frm = new FormABM(mostrarInfo);
            frm.ShowDialog();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            RemoverElemento();
            FormatearDataGrid();
        }
        /// <summary>
        /// Elimina la primer fila que contenga una celda seleccionada
        /// </summary>
        private void RemoverElemento()
        {
            foreach (DataGridViewRow fila in dgvMostrar.Rows)
            {
                if (FilaContieneCeldaSeleccionada(fila))
                {
                    ControladorMostrar.Eliminar(Convert.ToInt32(fila.Cells[0].Value),mostrarInfo);
                    break;
                }
            }
        }
        /// <summary>
        /// Verifica si una fila contiene alguna celda seleccionada
        /// </summary>
        /// <param name="fila">Fila a verificar</param>
        /// <returns>Retorna true si la fila contiene al menos una celda seleccionada. 
        /// Retorna false si la fila no contiene celdas seleccionadas</returns>
        private bool FilaContieneCeldaSeleccionada(DataGridViewRow fila)
        {
            foreach(DataGridViewCell cell in fila.Cells)
            {
                if (cell.Selected)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRellenarNotificar_Click(object sender, EventArgs e)
        {
            RellenarONotificar();
            FormatearDataGrid();
        }
        /// <summary>
        /// Permite rellenar el stock en caso de que el usuario logueado sea administrador, o notificar a uno 
        /// de bajas existencias en un producto en caso de que el usuario sea un empleado 
        /// </summary>
        private void RellenarONotificar()
        {
            if (ControladorMostrar.UsuarioEsAdmin)
            {
                FormRellenar formRellenar = new FormRellenar();
                formRellenar.ShowDialog();
                if (formRellenar.DialogResult == DialogResult.Yes)
                {
                    RellenarStock();
                }
                else
                {
                    if (formRellenar.DialogResult == DialogResult.No)
                    {
                        RellenarStock(formRellenar.Cantidad);
                    }
                }
            }
            else
            {
                NotificarFaltante();
            }
        }
    }
}
