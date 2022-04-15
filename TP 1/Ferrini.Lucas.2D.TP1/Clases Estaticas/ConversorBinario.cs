using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversores
{
    public static class ConversorBinario
    {
        /// <summary>
        /// Convierte un numero decimal a su representacion en binario
        /// </summary>
        /// <param name="numero">Numero a representar en binario</param>
        /// <returns></returns>
        public static string DecimalABinario(int numero)
        {
            List<int> numeroBinario;

            numeroBinario = CargarNumeros(numero);
            return InvertirCadena(numeroBinario);
            
        }

        private static string InvertirCadena(List<int> restos)
        {
            StringBuilder binario = new StringBuilder();
            for (int i = restos.IndexOf(restos.Last()); i >= 0; i--)
            {
                binario.Append(restos[i]);
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
            if(numeroStr is not null)
            {
                potencia = numeroStr.Length;
                resultado = 0;
                for (int i=0;i<numeroStr.Length;i++)
                {
                    potencia--;
                    if(numeroStr[i] == '1' || numeroStr[i] == '0')
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
