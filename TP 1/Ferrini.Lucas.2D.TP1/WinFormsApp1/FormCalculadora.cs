using Logica;
using Validacion;

using System;
using System.Windows.Forms;
using System.Text;

namespace WinFormsApp1
{
    public partial class FormCalculadora : Form
    {
        private string resultado;
        private bool esBinario;
        /// <summary>
        /// Inicializa los componentes del formulario 
        /// </summary>
        public FormCalculadora()
        {
            resultado = string.Empty;
            esBinario = false;
            InitializeComponent();
        }
        /// <summary>
        /// Evento del boton operar que llama a la funcion Operar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            Operar();
        }
        /// <summary>
        /// Realiza la operacion seleccionada entre ambos operandos. Si no hay opcion seleccionada por defecto
        /// realiza una suma
        /// </summary>
        private void Operar()
        {

            if (Controlador.CargarOperandos(txtNumero1.Text, txtNumero2.Text))
            {
                string operador = ValidarOperador();
                string operacion = Operar(operador);
                if (txtNumero2.Text == "0" && operador == "/")
                {
                    MessageBox.Show("Error: No se puede calcular el resultado de una division por 0");
                }
                MostrarOperacion(operacion);
            }
        }
        /// <summary>
        /// Crea el mensaje a mostrar en el listado de operaciones
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private string Operar(string operador)
        {
            
            string primerOperando = ValidarOperando(txtNumero1);
            string segundoOperando = ValidarOperando(txtNumero2);
            resultado = Controlador.CalcularOperacion(operador).ToString();
            esBinario = false;
            return $"{primerOperando} {operador} {segundoOperando} = {resultado}\n";
        }
        /// <summary>
        /// Valida que el TextBox recibido no contenga un string vacio o caracteres
        /// </summary>
        /// <param name="textBox">Textbox a validar</param>
        /// <returns>El contenido de la propiedad Text si el valor recibido es numérico, o 0 en otro caso</returns>
        private static string ValidarOperando(TextBox textBox)
        {
            string operando = "0";
            if(!string.IsNullOrWhiteSpace(textBox.Text) && Validador.EsNumerico(textBox.Text))
            {
                operando = textBox.Text;
            }
            return operando;
        }
        /// <summary>
        /// Valida que el operador seleccionado sea válido para imprimirlo por pantalla
        /// </summary>
        /// <returns>Operacion a realizar</returns>
        private string ValidarOperador()
        {
            string operador = cmbOperador.Text;
            if (operador == string.Empty)
            {
                operador = "+";
            }
            return operador;
        }
        /// <summary>
        /// Muesta una operacion y la añade a la lista de operaciones realizadas
        /// </summary>
        /// <param name="operacion">Operacion a imprimir</param>
        private void MostrarOperacion(string operacion)
        {
            lblResultado.Text = resultado;
            lstOperaciones.BeginUpdate();
            lstOperaciones.Items.Add(operacion);
            lstOperaciones.EndUpdate();
        }
        /// <summary>
        /// Evento que llama al método Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Limpia el contenido de la lista de operaciones, el contenido de los TextBox y el ComboBox
        /// </summary>
        private void Limpiar()
        {
            lstOperaciones.Items.Clear();
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            cmbOperador.Text = string.Empty;
            lblResultado.Text = "0";
        }
        /// <summary>
        /// Evento del boton Cerrar que llama al método Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Evento del boton Convertir a Decimal que llama al metodo ConvertirBinarioADecimal 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnBinarioADecimal_Click(object sender, EventArgs e)
        {
            ConvertirBinarioADecimal();
        }
        /// <summary>
        /// Convierte el resultado de la última operacion de binario a decimal
        /// </summary>
        private void ConvertirBinarioADecimal()
        {
            StringBuilder operacion = new StringBuilder();
            if (resultado != string.Empty)
            {
                if(esBinario)
                {
                    operacion.Append($"{resultado} (B) =");
                    resultado = Controlador.ConvertirADecimal(resultado);
                    operacion.Append($" {resultado} (D)");
                    lblResultado.Text = resultado;
                    esBinario = false;
                    MostrarOperacion(operacion.ToString());
                }
                else
                {
                    MessageBoxButtons boton = MessageBoxButtons.OK;
                    MessageBoxIcon icono = MessageBoxIcon.Information;
                    MessageBox.Show("Este numero ya es decimal", "Error", boton, icono);
                }
            }
            else
            {
                MostrarErrorDeConversion();
            }
        }
        /// <summary>
        /// Evento del boton Convertir a Binario que llama al metodo ConvertirDecimalABinario 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecimalABinario_Click(object sender, EventArgs e)
        {
            ConvertirDecimalABinario();
        }
        /// <summary>
        /// Convierte el resultado de la última operacion de decimal a binario
        /// </summary>
        private void ConvertirDecimalABinario()
        {
            StringBuilder operacion = new StringBuilder();
            if (resultado != string.Empty)
            {
                if(!esBinario)
                {
                    operacion.Append($"{resultado} (D) =");
                    resultado = Controlador.ConvertirABinario(resultado);
                    operacion.Append($" {resultado} (B)");
                    lblResultado.Text = resultado;
                    esBinario = true;
                    MostrarOperacion(operacion.ToString());
                }
                else
                {
                    MessageBoxButtons boton = MessageBoxButtons.OK;
                    MessageBoxIcon icono = MessageBoxIcon.Information;
                    MessageBox.Show("Este numero ya es binario", "Error", boton, icono);
                }
            }
            else
            {
                MostrarErrorDeConversion();
            }
        }
        /// <summary>
        /// Pregunta al usuario si esta seguro de querer abandonar la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Muestra un mensaje de error en caso de querer convertir a binario o a 
        /// decimal sin haber hecho una operacion
        /// </summary>
        private static void MostrarErrorDeConversion()
        {
            MessageBoxButtons botonera = MessageBoxButtons.OK;
            MessageBoxIcon icono = MessageBoxIcon.Error;
            MessageBox.Show("Error: Debe realizar una operacion antes de convertir el resultado.", 
                            "Error", botonera, icono);
        }
    }
}
