using Logica.Caja;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormCaja : Form
    {
        public FormCaja()
        {
            InitializeComponent();
        }

        private void FormCaja_Load(object sender, EventArgs e)
        {
            ActualizarInterfaz();
        }
        /// <summary>
        /// Actualiza la interfaz luego de realizar un cambio
        /// </summary>
        private void ActualizarInterfaz()
        {
            rtxtListaProductos.Text = ControladorCaja.MostrarVenta();
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            Cobrar();
        }
        /// <summary>
        /// Intenta realizar el cobro por la mesa e informa al usuario el resultado
        /// a traves de un mensaje
        /// </summary>
        private void Cobrar()
        {
            string mensaje;
            string titulo = "Error";
            MessageBoxButtons boton = MessageBoxButtons.OK;
            MessageBoxIcon icono = MessageBoxIcon.Error;
            DialogResult resultado = DialogResult.Abort;
            try
            {
                if (ControladorCaja.Cobrar())
                {
                    mensaje = "Operacion realizada con exito";
                    titulo = "Operacion realizada";
                    icono = MessageBoxIcon.Information;
                    resultado = DialogResult.OK;
                }
                else
                {
                    throw new Exception("No se pudo realizar el cobro de esta venta");
                }
                MessageBox.Show(mensaje,titulo,boton, icono);
                if(resultado == DialogResult.OK)
                {
                    DialogResult = resultado;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, titulo, boton, icono);
            }
        }

        private void MetodoPago_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarInterfaz();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
