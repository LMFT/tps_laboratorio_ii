using Entidades;

using Logica.AgregarPedidos;
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
        /// <returns>Retorna true si pudo añadir la operacion exitosamente, de lo contrario false</returns>
        public static bool Cobrar()
        {
            try
            {
                bool operacionExitosa = CasaElectronica.NuevaOperacion(ControladorAgregar.Productos);
                if (operacionExitosa)
                  {
                    ControladorAgregar.LimpiarProductos();
                  }
                return operacionExitosa;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string MostrarVenta()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Producto producto in ControladorAgregar.Productos)
            {
                sb.AppendLine($"{producto.Mostrar()}\n");
            }
            return sb.ToString();
        }
    }
}
