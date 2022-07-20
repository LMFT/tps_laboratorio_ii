using System;

namespace Extensiones
{
    public static class Validacion
    {
        /// <summary>
        /// Muestra un mensaje en consola pidiendo confirmacion y compara la respuesta con un caracter dado
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar</param>
        /// <param name="confirmacion">Caracter de confirmacion</param>
        /// <returns>Retorna </returns>
        public static bool PedirConfirmacion(string mensaje, char confirmacion)
        {
            Console.WriteLine(mensaje);
            if(Console.Read() == confirmacion)
            {
                return true;
            }
            return false;
        }

        public static bool ValidarRango( int numero,int minimo, int maximo)
        {
            if(numero <= maximo && numero >= minimo)
            {
                return true;
            }
            return false;
        }
    }
}
