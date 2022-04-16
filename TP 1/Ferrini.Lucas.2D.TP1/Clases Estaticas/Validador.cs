using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validacion
{
    /// <summary>
    /// Esta clase contiene varios métodos para validarvalores
    /// </summary>
    public static class Validador
    {
        /// <summary>
        /// Verifica que una cadena de caracteres esté compuesta por únicamente números
        /// </summary>
        /// <param name="cadena">Cadena a verificar</param>
        /// <returns>Retornará true cuando la cadena recibida sea de tipo numérico</returns>
        public static bool EsNumerico(string cadena)
        {
            return double.TryParse(cadena, out double n);
        }
    }
}
