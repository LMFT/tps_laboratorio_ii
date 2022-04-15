namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Operando operando1, Operando operando2, char operador)
        {
            switch (ValidarOperador(operador))
            {
                case '-':
                    return operando1 - operando2;
                case '*':
                    return operando1 * operando2;
                case '/':
                    return operando1 / operando2;
                default:
                    return operando1 + operando2;
            }
        }

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
