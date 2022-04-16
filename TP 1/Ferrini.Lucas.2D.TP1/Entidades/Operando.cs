
using Conversores;
namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Inicializa el operando con el valor de 0
        /// </summary>
        public Operando()
        {
            numero = 0;
        }
        /// <summary>
        /// Inicializa el operando con el valor recibido como parámetro
        /// </summary>
        /// <param name="numero">Valor a asignar al operando</param>
        public Operando(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Inicializa el operando con la representacion numérica del valor recibido como parámetro
        /// </summary>
        /// <param name="strNumero">Valor a asignar al operando</param>
        public Operando(string strNumero)
        {
            Numero = strNumero;
        }
        /// <summary>
        /// Valida y asigna un valor en formato texto al atributo número
        /// </summary>
        private string Numero
        {
            set
            {
                numero = ValidarOperando(value);
            }
        }
        /// <summary>
        /// Valida que la cadena recibida como parámetro esté compuesta por numeros y retorna su valor 
        /// </summary>
        /// <param name="strNumero">Cadena a validar</param>
        /// <returns>El valor recibido como parámetro en formato número, o 0 si la cadena recibida no pudo 
        /// convertirse a valor numérico</returns>
        private double ValidarOperando(string strNumero)
        {
            if (double.TryParse(strNumero, out double numero))
            {
                return numero;
            }
            return 0;
        }
        /// <summary>
        /// Valida que el valor recibido como parámetro sea en formato binario (solamente compuesta por 1 y 0)
        /// </summary>
        /// <param name="strNumero">Numero a verificar</param>
        /// <returns>Retorna true si la cadena está en formato binario, de lo contrario false</returns>
        public bool EsBinario(string strNumero)
        {
            char[] arrayNumeros = strNumero.ToCharArray();
            if (int.TryParse(strNumero, out int esNumerico))
            {
                for (int i = 0; i < strNumero.Length; i++)
                {
                    if (arrayNumeros[i] != '0' && arrayNumeros[i] != '1')
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// Convierte un número binario a decimal
        /// </summary>
        /// <param name="binario">Número a convertir</param>
        /// <returns>Número convertido a decimal, o una cadena vacía si 
        /// la cadena recibida contiene valores no binarios</returns>
        public string BinarioADecimal(string binario)
        {
            if (EsBinario(binario))
            {
                return ConversorBinario.BinarioADecimal(binario).ToString();
            }
            return string.Empty;
        }
        /// <summary>
        /// Convierte un número decimal a binario
        /// </summary>
        /// <param name="_decimal">Número a convertir</param>
        /// <returns>Número convertido a binario</returns>
        public string DecimalBinario(double _decimal)
        {
            return ConversorBinario.DecimalABinario((int)_decimal);
        }
        /// <summary>
        /// Convierte en numero decimal recibido a formato binario
        /// </summary>
        /// <param name="_decimal">Numero a convertir a decimal</param>
        /// <returns>Número convertido a binario, o una cadena vacia si 
        /// la cadena recibida no pudo convertirse a número</returns>
        public string DecimalABinario(string _decimal)
        {
            if (int.TryParse(_decimal, out int numeroDecimal))
            {
                return DecimalBinario(numeroDecimal);
            }
            return string.Empty;
        }
        /// <summary>
        /// Permite realizar la operacion suma entre dos objetos del tipo Operando
        /// </summary>
        /// <param name="o1">Primer operando</param>
        /// <param name="o2">Segundo operando</param>
        /// <returns>Resultado de la suma entre los operandos</returns>
        public static double operator +(Operando o1, Operando o2)
        {
            return o1.numero + o2.numero;
        }
        /// <summary>
        /// Permite realizar la operacion resta entre dos objetos del tipo Operando
        /// </summary>
        /// <param name="o1">Primer operando</param>
        /// <param name="o2">Segundo operando</param>
        /// <returns>Resultado de la resta entre los operandos</returns>
        public static double operator -(Operando o1, Operando o2)
        {
            return o1.numero - o2.numero;
        }
        /// <summary>
        /// Permite realizar la operacion producto entre dos objetos del tipo Operando
        /// </summary>
        /// <param name="o1">Primer operando</param>
        /// <param name="o2">Segundo operando</param>
        /// <returns>Resultado de la producto entre los operandos</returns>
        public static double operator *(Operando o1, Operando o2)
        {
            return o1.numero * o2.numero;
        }
        /// <summary>
        /// Permite realizar la operacion division entre dos objetos del tipo Operando
        /// </summary>
        /// <param name="o1">Primer operando</param>
        /// <param name="o2">Segundo operando</param>
        /// <returns>Resultado de la division entre los operandos, o NaN si el divisor es 0</returns>
        public static double operator /(Operando o1, Operando o2)
        {
            if (o2.numero != 0)
            {
                return o1.numero / o2.numero;
            }
            return double.NaN;
        }


    }
}
