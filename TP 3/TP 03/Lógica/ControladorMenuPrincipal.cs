using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Almacenamiento;
using Logica.AgregarPedidos;
using Logica.Login;

namespace Logica.MenuPrincipal
{
    public static class ControladorMenuPrincipal
    {
        private static List<Tarea> tareasPendientes;

        static ControladorMenuPrincipal()
        {
            tareasPendientes = new List<Tarea>();
        }
        public static string UsuarioLogeado
        {
            get
            {
                return ControladorLogin.UsuarioLogeado.NombreCompleto;
            }
        }

        public static bool UsuarioEsAdmin
        {
            get
            {
                return (int)ControladorLogin.UsuarioLogeado.Permisos > 0;
            }
        }

        public static Permisos Permisos
        {
            get
            {
                return ControladorLogin.UsuarioLogeado.Permisos;
            }
        }
        /// <summary>
        /// Permite agregar los pedidos cargados en el controlador Agregar a la lista de pedidos asociada a lamesa
        /// </summary>
        /// <param name="indiceMesa">Mesa a la cual asignar los pedidos</param>
        /// <returns>Retorna true si se pudieron asignar correctamente los pedidos. De lo contrario false</returns>
        public static bool AgregarPedidos(int indiceMesa)
        {
            if (indiceMesa >= 0)
            {
                return true;
            }
            return false;
        }

        public static void NuevaTarea(string descripcion)
        {
            tareasPendientes.Add(new Tarea(descripcion));
        }

        public static void Guardar(string ruta)
        {
            CasaElectronica.Guardar(ruta);
        }
    }
}
