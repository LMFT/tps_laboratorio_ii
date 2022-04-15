
using Conversores;
namespace Entidades
{
    public class Operando
    {
        private double numero;


        public Operando()
        {
            numero = 0;
        }
        public Operando(double numero)
        {
            this.numero = numero;
        }
        public Operando(string strNumero)
        {
            Numero = strNumero;
        }

        private string Numero
        {
            set
            {
                numero = ValidarOperando(value);
            }
        }

        private double ValidarOperando(string strNumero)
        {
            if (double.TryParse(strNumero, out double numero))
            {
                return numero;
            }
            return 0;
        }

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

        public string BinarioADecimal(string binario)
        {
            if (EsBinario(binario))
            {
                return ConversorBinario.BinarioADecimal(binario).ToString();
            }
            return string.Empty;
        }

        public string DecimalBinario(double _decimal)
        {
            return ConversorBinario.DecimalABinario((int)_decimal);
        }

        public string DecimalABinario(string _decimal)
        {
            if (int.TryParse(_decimal, out int numeroDecimal))
            {
                return DecimalBinario(numeroDecimal);
            }
            return "Valor inválido";
        }

        public static double operator +(Operando o1, Operando o2)
        {
            return o1.numero + o2.numero;
        }

        public static double operator -(Operando o1, Operando o2)
        {
            return o1.numero - o2.numero;
        }

        public static double operator *(Operando o1, Operando o2)
        {
            return o1.numero * o2.numero;
        }

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
