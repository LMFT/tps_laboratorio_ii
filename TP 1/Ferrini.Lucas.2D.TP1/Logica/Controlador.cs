
using Entidades;
namespace Logica
{
    /// <summary>
    /// Esta clase comunica los elementos de la interfaz con la lógica implementada en las clases
    /// </summary>
    public static class Controlador
    {
        private static Operando primerOperando;
        private static Operando segundoOperando;
        
        static Controlador()
        {
            CargarOperandos("0", "0");
        }
        /// <summary>
        /// Este método permite cargar un valor a los operandos del programa
        /// </summary>
        /// <param name="primerNumero">Valor a asignar al primer operando</param>
        /// <param name="segundoNumero">Valor a asignar al segundo operando</param>
        public static bool CargarOperandos(string primerNumero, string segundoNumero)
        {
            bool operandosCargados = primerNumero is not null && segundoNumero is not null;
            if (operandosCargados)
            {
                primerOperando = new Operando(primerNumero);
                segundoOperando = new Operando(segundoNumero);
            }
            return operandosCargados;
        }
        
        /// <summary>
        /// Realiza la operacion recibida como parámetro utilizando los operandos actuales
        /// </summary>
        /// <param name="operacion">Operacion a realizar</param>
        /// <returns>Resultado de la operacion solicitada entre los operandos</returns>
        public static double CalcularOperacion(string operacion)
        {
            char operador = ValidarOperacion(operacion);
            return Calculadora.Operar(primerOperando, segundoOperando, operador);
        }
        /// <summary>
        /// Valida que la cadena recibida como parámetro sea utilizable por la funcion Operar
        /// </summary>
        /// <param name="operacion">Operacion a validar</param>
        /// <returns>La operacion a realizar en formato caracter</returns>
        private static char ValidarOperacion(string operacion)
        {
            char operador = '+';
            if (!string.IsNullOrWhiteSpace(operacion))
            {
                operador = operacion[0];
            }
            return operador;
        } 
        /// <summary>
        /// Convierte el numero recibido como parámetro a su representación en binario
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Numero convertido a binrio en formato string,
        /// o "Valor inválido" si el valor recibido no es numérico</returns>
        public static string ConvertirABinario(string numero)
        {
            Operando operando = new Operando(numero);
            string numeroBinario = string.Empty;
            string valorAbsoluto = numero;
            if (numero[0]== '-')
            {
                numeroBinario += "-";
                valorAbsoluto = numero.Substring(1);
            }
            numeroBinario += operando.DecimalABinario(valorAbsoluto);
            return numeroBinario;
        }
        /// <summary>
        /// Convierte un número binario a su representacion decimal
        /// </summary>
        /// <param name="numero">Número binario a convertir</param>
        /// <returns>Número convertido a decimal en formato string</returns>
        public static string ConvertirADecimal(string numero)
        {
            Operando operando = new Operando(numero);
            string numeroDecimal = string.Empty;
            string valorAbsoluto = numero;
            if (numero[0] == '-')
            {
                numeroDecimal += "-";
                valorAbsoluto = numero.Substring(1);
            }
            numeroDecimal += operando.BinarioADecimal(valorAbsoluto);
            return numeroDecimal;
        }

    }
}
