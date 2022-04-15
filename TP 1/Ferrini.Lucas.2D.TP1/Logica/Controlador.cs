using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
namespace Logica
{
    public static class Controlador
    {
        private static Operando primerOperando;
        private static Operando segundoOperando;

        static Controlador()
        {
            primerOperando = new Operando();
            segundoOperando = new Operando();
        }

        public static double GetPrimerOperando()
        {
            Operando cero = new Operando();
            return primerOperando + cero;
        }

        public static double GetSegundoOperando()
        {
            Operando cero = new Operando();
            return segundoOperando + cero;
        }

        public static bool ValidarOperandos(string primerNumero, string segundoNumero)
        {
            bool operandosCargados = primerNumero is not null && segundoNumero is not null;
            if (operandosCargados)
            {
                primerOperando = new Operando(primerNumero);
                segundoOperando = new Operando(segundoNumero);
            }
            return operandosCargados;
        }

        public static double CalcularOperacion(string operacion)
        {
            char operador = '+';
            if(operacion is not null && operacion.Length > 0)
            {
                operador = operacion[0];
            }
            return Calculadora.Operar(primerOperando, segundoOperando, operador);
        }

        public static string ConvertirABinario(string numero)
        {
            Operando operando = new Operando(numero);
            return operando.DecimalABinario(numero);
        }
        public static string ConvertirADecimal(string numero)
        {
            Operando operando = new Operando(numero);
            return operando.BinarioADecimal(numero);
        }
    }
}
