using Entidades;

using Logica.MenuPrincipal;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Caja
{
    public enum MetodoPago
    {
        Efectivo,
        Credito,
        Debito
    }
    public static class ControladorCaja
    {
        public static bool UsuarioEsAdmin
        {
            get
            {
                return ControladorMenuPrincipal.UsuarioEsAdmin;
            }
        }

        /// <summary>
        /// Registra una nueva operacion en el historial
        /// </summary>
        /// <param name="indiceMesa">Indice de la mesa sobre la cual hicimos la operacion</param>
        /// <returns>Retorna true si pudo añadir la operacion exitosamente, de lo contrario false</returns>
        public static bool Cobrar(int indiceMesa)
        {
            return CasaElectronica.NuevaOperacion(indiceMesa);
        }
    }
}
