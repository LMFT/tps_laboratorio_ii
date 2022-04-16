using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conversores
{
    public static class ConversorBinario
    {
        /// <summary>
        /// Convierte un numero decimal a su representacion en binario
        /// </summary>
        /// <param name="numero">Numero a representar en binario</param>
        /// <returns>Numero convertido a binario</returns>
        public static string DecimalABinario(int numero)
        {
            List<int> numeroBinario;

            numeroBinario = CargarNumeros(numero);
            return InvertirLista(numeroBinario);
        }
        /// <summary>
        /// Invierte una lista de números
        /// </summary>
        /// <param name="listaNumeros">Listado de numeros a invertir</param>
        /// <returns>Cadena de caracteres invertida</returns>
        private static string InvertirLista(List<int> listaNumeros)
        {
            StringBuilder binario = new StringBuilder();
            if (listaNumeros is not null)
            {
                listaNumeros.Reverse();
                for (int i = 0; i < listaNumeros.Count; i++)
                {
                    binario.Append(listaNumeros[i]);
                }
            }
            return binario.ToString();
        }
        /// <summary>
        /// Crea una lista de números que representa el valor recibido como parámetro en binario, pero con sus valores 
        /// invertidos (el numero 1010 se guardaría como 0101)
        /// </summary>
        /// <param name="numero">Número a representar</param>
        /// <returns>Lista de números con la representacion binaria de un numero</returns>
        private static List<int> CargarNumeros(int numero)
        {
            List<int> restos = new List<int>();
            while (numero >= 1)
            {
                restos.Add(numero % 2);
                numero /= 2;
            }
            return restos;
        }
        /// <summary>
        /// Convierte un número de binario a decimal
        /// </summary>
        /// <param name="numeroStr">Cadena que representa un número binario</param>
        /// <returns></returns>
        public static int BinarioADecimal(string numeroStr)
        {
            double resultado = -1;
            int potencia;
            if (numeroStr is not null && EsBinario(numeroStr))
            {
                potencia = numeroStr.Length;
                resultado = 0;
                for (int i = 0; i < numeroStr.Length; i++)
                {
                    potencia--;
                    if (numeroStr[i] == '1' || numeroStr[i] == '0')
                    {
                        resultado += Math.Pow(2, potencia) * int.Parse(numeroStr[i].ToString());
                    }
                    else
                    {
                        return int.MinValue;
                    }
                }
            }
            return (int)resultado;
        }
        /// <summary>
        /// Valida que el valor recibido como parámetro sea en formato binario (solamente compuesta por 1 y 0)
        /// </summary>
        /// <param name="numeroStr">Numero a verificar</param>
        /// <returns>Retorna true si la cadena está en formato binario, de lo contrario false</returns>
        public static bool EsBinario(string numeroStr)
        {
            foreach(char c in numeroStr)
            {
                if(c != '1' && c != '0')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
