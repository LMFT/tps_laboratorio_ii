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
        }

        public FormMostrar(MostrarInfo mostrar) : this()
        {
            mostrarInfo = mostrar;
            ConfigurarBotones();
            FormatearDataGrid();
            CambiarTitulo();
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

            switch (mostrarInfo)
            {
                case MostrarInfo.Producto:
                    dgvMostrar.DataSource = ControladorMostrar.Inventario;
                    break;
                case MostrarInfo.Empleado:
                    dgvMostrar.DataSource = ControladorMostrar.Empleados;
                    break;
                default:
                    dgvMostrar.DataSource = null;
                    break;
            }
            OrdenarColumnas();
        }

        private void OrdenarColumnas()
        {
            switch (mostrarInfo)
            {
                case MostrarInfo.Producto:
                    //customersDataGridView.Columns["ContactName"].DisplayIndex = 0;
                    dgvMostrar.Columns["Id"].DisplayIndex = 0;
                    dgvMostrar.Columns["Nombre"].DisplayIndex = 1;
                    dgvMostrar.Columns["Precio"].DisplayIndex = 2;
                    dgvMostrar.Columns["Cantidad"].DisplayIndex = 3;
                    break;
                case MostrarInfo.Empleado:
                    dgvMostrar.Columns["Dni"].DisplayIndex = 0;
                    dgvMostrar.Columns["Nombre"].DisplayIndex = 1;
                    dgvMostrar.Columns["Apellido"].DisplayIndex = 2;
                    dgvMostrar.Columns["Permisos"].DisplayIndex = 3;
                    dgvMostrar.Columns["NombreUsuario"].DisplayIndex = 4;
                    dgvMostrar.Columns["NombreCompleto"].Visible = false;
                    dgvMostrar.Columns["EstaActivo"].DisplayIndex = 5;
                    break;
                default:
                    break;
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
        /// Selecciona la primer fila que contenga una celda seleccionada
        /// </summary>
        /// <returns>Primer fila que contenga una celda seleccionada.</returns>
        private DataGridViewRow SeleccionarFila()
        {
            return dgvMostrar.SelectedCells[0].OwningRow;
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
            int id = Convert.ToInt32(SeleccionarFila().Cells[0].Value);
            ControladorMostrar.Eliminar(id, mostrarInfo);
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

        private void NotificarFaltante()
        {
            var elemento = dgvMostrar.SelectedRows[0].DataBoundItem;
            ControladorMostrar.NotificarFaltante(elemento);
        }
    }
}
