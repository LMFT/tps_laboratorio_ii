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
        /// <param name="cadena">Cadena a invertir</param>
        /// <returns>Cadena de caracteres invertida</returns>
        private static string InvertirLista(List<int> cadena)
        {
            StringBuilder binario = new StringBuilder();
            if (cadena is not null)
            {
                cadena.Reverse();
                //for (int i = cadena.IndexOf(cadena.Last()); i >= 0; i--)
                for (int i = 0; i < cadena.Count; i++)
                {
                    binario.Append(cadena[i]);
                }
            }
            return binario.ToString();
        }
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


        public static int BinarioADecimal(string numeroStr)
        {
            double resultado = -1;
            int potencia;
            if (numeroStr is not null)
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
    }
}
