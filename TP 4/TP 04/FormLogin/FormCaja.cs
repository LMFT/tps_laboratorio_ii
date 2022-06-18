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
        private int indiceMesa;
        private FormCaja()
        {
            InitializeComponent();
        }

        public FormCaja(int indiceMesa) : this()
        {
            this.indiceMesa = indiceMesa;
        }
        /// <summary>
        /// Cambia el color de la aplicacion en base a los permisos del usuario logueado
        /// </summary>
        private void CambiarColor()
        {
            if (!ControladorCaja.UsuarioEsAdmin)
            {
                BackColor = Color.LightSkyBlue;
                rtxtInfoMesa.BackColor = Color.LightBlue;
                nudCuotas.BackColor = Color.LightBlue;
                foreach (Control control in Controls.OfType<Button>())
                {
                    control.BackColor = Color.PowderBlue;
                }
            }
            else
            {
                BackColor = Color.Tan;
                rtxtInfoMesa.BackColor = Color.NavajoWhite;
                foreach (Control control in Controls.OfType<Button>())
                {
                    control.BackColor = Color.Moccasin;
                }
            }
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
            rtxtInfoMesa.Text = String.Empty;
            foreach(RadioButton rdo in grpMetodoPago.Controls.OfType<RadioButton>())
            {
                if (rdo.Checked)
                {
                    rtxtInfoMesa.Text = ControladorCaja.CalcularTotal(indiceMesa, Convert.ToInt32(rdo.Tag)); ;
                }
            }
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
            string titulo;
            MessageBoxButtons boton = MessageBoxButtons.OK;
            MessageBoxIcon icono;
            DialogResult resultado;
            if (ControladorCaja.Cobrar(indiceMesa))
            {
                mensaje = "Operacion realizada con exito";
                titulo = "Operacion realizada";
                icono = MessageBoxIcon.Information;
                resultado = DialogResult.OK;
            }
            else
            {
                mensaje = "No se pudo realizar el cobro del producto";
                titulo = "Operacion fallida";
                icono = MessageBoxIcon.Error;
                resultado = DialogResult.Abort;
            }
            MessageBox.Show(mensaje,titulo,boton, icono);
            if(resultado == DialogResult.OK)
            {
                DialogResult = resultado;
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
