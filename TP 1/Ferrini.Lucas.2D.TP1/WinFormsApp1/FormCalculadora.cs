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

            if (Controlador.CargarOperandos(txbPrimerOperador.Text, txbSegundoOperador.Text))
            {
                string operador = ValidarOperador();
                string operacion = Operar(operador);
                if (txbSegundoOperador.Text == "0" && operador == "/")
                {
                    MessageBox.Show("Error: No se puede calcular el resultado de una division por 0");
                }
                ListarOperacion(operacion);
            }
        }
        /// <summary>
        /// Crea el mensaje a mostrar en el listado de operaciones
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private string Operar(string operador)
        {
            
            string primerOperando = ValidarOperando(txbPrimerOperador);
            string segundoOperando = ValidarOperando(txbSegundoOperador);
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
            string operador = cbxOperacion.Text;
            if (operador == string.Empty)
            {
                operador = "+";
            }
            return operador;
        }
        /// <summary>
        /// Añade una operacion a la lista de operaciones realizadas
        /// </summary>
        /// <param name="operacion">Operacion a imprimir</param>
        private void ListarOperacion(string operacion)
        {
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
            txbPrimerOperador.Text = string.Empty;
            txbSegundoOperador.Text = string.Empty;
            cbxOperacion.Text = string.Empty;
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
                    esBinario = false;
                    ListarOperacion(operacion.ToString());
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
                    esBinario = true;
                    ListarOperacion(operacion.ToString());
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
