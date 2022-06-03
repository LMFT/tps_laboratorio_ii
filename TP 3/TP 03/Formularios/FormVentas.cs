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

namespace Formularios
{
    public partial class FormAgregar : Form
    {
        //Indica si el formulario se abrio con el proposito de realizar un nuevo pedido (venta)
        //o para agregar productos al listado de un proveedor
        private bool venta;
        private FormAgregar()
        {
            InitializeComponent();
        }

        public FormAgregar(bool venta) : this()
        {
            this.venta = venta;
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
            try
            {
                if (venta)
                {
                    ControladorAgregar.EliminarPedido(lstAgregados.SelectedItem, (int)nudCantidad.Value);
                }
                else
                {
                    ControladorAgregar.EliminarProducto(lstAgregados.SelectedItem);
                }

            }
            catch (Exception ex)
            {
                MostrarMensaje(false, ex.Message, "Error");
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
            try
            {
                if (venta)
                {
                    if (ControladorAgregar.NuevoPedido(lstExistencias.SelectedItem, (int)nudCantidad.Value))
                    {
                        MostrarMensaje(true, "El pedido se realizó exitosamente", "Exito");
                    }
                }
                else
                {
                    if (!venta)
                    {
                        ControladorAgregar.AgregarProducto(lstExistencias.SelectedItem);
                    }
                }
            }
            catch(Exception ex)
            {
                MostrarMensaje(false, ex.Message, "Error");
            }
        }
        /// <summary>
        /// Actualiza la interfaz gráfica luego de realizarse un cambio
        /// </summary>
        private void ActualizarInterfaz()
        {
            lstAgregados.Update();
            lstExistencias.Update();
            lstAgregados.Refresh();
            lstExistencias.Refresh();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void MostrarMensaje(bool operacionExitosa, string mensaje, string titulo)
        {
            MessageBoxButtons boton = MessageBoxButtons.OK;
            MessageBoxIcon icono = MessageBoxIcon.Error;
            if (operacionExitosa)
            {
                icono = MessageBoxIcon.Information;
            }
            MessageBox.Show(mensaje, titulo, boton, icono);
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            lstAgregados.DataSource = ControladorAgregar.Inventario;
            if (!venta)
            {
                nudCantidad.Hide();
            }
        }
    }
}
