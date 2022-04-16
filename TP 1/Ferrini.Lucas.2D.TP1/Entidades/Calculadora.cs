namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza la operacion recibida entre los operandos recibidos. En caso de recibir una
        /// operacion inválida realiza la operacion suma
        /// </summary>
        /// <param name="primerOperando">Primer número a operar</param>
        /// <param name="segundoOperando">Segundo número a operar</param>
        /// <param name="operador">Operacion a realizar</param>
        /// <returns>Resultado de la operacion realizada</returns>
        public static double Operar(Operando primerOperando, Operando segundoOperando, char operador)
        {
            switch (ValidarOperador(operador))
            {
                case '-':
                    return primerOperando - segundoOperando;
                case '*':
                    return primerOperando * segundoOperando;
                case '/':
                    return primerOperando / segundoOperando;
                default:
                    return primerOperando + segundoOperando;
            }
        }
        /// <summary>
        /// Valida que el operador sea apropiado para realizar una operacion
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>La operacion validada. En caso de haber recibido una operacion inválida
        /// por defecto retorna suma</returns>
        private static char ValidarOperador(char operador)
        {
            if (operador == '-' || operador == '*' || operador == '/')
            {
                return operador;
            }
            return '+';
        }
    }
}
