using Logica;

using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormCalculadora : Form
    {
        string resultado;
        string resultadoBinario;
        public FormCalculadora()
        {
            resultado = string.Empty;
            resultadoBinario = string.Empty;
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Operar();
        }

        private void Operar()
        {
            string operacion;
            if (Controlador.ValidarOperandos(txbPrimerOperador.Text, txbSegundoOperador.Text))
            {
                string operador = cbxOperacion.Text;
                if (operador == string.Empty)
                {
                    operador = "+";
                }
                resultado = (Controlador.CalcularOperacion(operador)).ToString();
                operacion = $"{Controlador.GetPrimerOperando()} {operador} {Controlador.GetSegundoOperando()} = {resultado}\n";
                if (txbSegundoOperador.Text == "0" && operador == "/")
                {
                    MessageBox.Show("Error: No se puede calcular el resultado de una division por 0");
                }
                ListarOperacion(operacion);
            }
        }

        private void ListarOperacion(string operacion)
        {
            lstOperaciones.BeginUpdate();
            lstOperaciones.Items.Add(operacion);
            lstOperaciones.EndUpdate();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            lstOperaciones.Items.Clear();
            txbPrimerOperador.Text = string.Empty;
            txbSegundoOperador.Text = string.Empty;
            cbxOperacion.Text = string.Empty;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBinarioADecimal_Click(object sender, EventArgs e)
        {
            if (resultadoBinario != string.Empty)
            {
                resultado = Controlador.ConvertirADecimal(resultadoBinario);
                string operacion = $"{resultadoBinario}(B) = {resultado}(D)";
                ListarOperacion(operacion);
            }
            else
            {
                MostrarErrorDeConversion();
            }
        }

        private void btnDecimalABinario_Click(object sender, EventArgs e)
        {
            if (resultado != string.Empty)
            {
                resultadoBinario = Controlador.ConvertirABinario(resultado);
                string operacion = $"{resultado}(D) = {resultadoBinario}(B)";
                ListarOperacion(operacion);
            }
            else
            {
                MostrarErrorDeConversion();
            }
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBoxButtons botones = MessageBoxButtons.YesNo;
            MessageBoxIcon icono = MessageBoxIcon.Information;
            DialogResult respuesta = MessageBox.Show("Desea cerrar la aplicacion?",
                                                     "Salir", botones, icono);
            if (respuesta == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private static void MostrarErrorDeConversion()
        {
            MessageBoxButtons botonera = MessageBoxButtons.OK;
            MessageBoxIcon icono = MessageBoxIcon.Error;
            MessageBox.Show("Error: Debe realizar una operacion antes de convertir el resultado.", "Error", botonera, icono);
        }
    }
}
