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

        public static ImmutableList<Tarea> Tareas
        {
            get
            {
                return CasaElectronica.Tareas;
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
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("Esta descripcion no es valida");
            }
            CasaElectronica.NuevaTarea(descripcion);
        }

        public static void EditarTarea(object elemento, string descripcion)
        {
            try
            {
                if(elemento is null)
                {
                    throw new NullReferenceException("No hay ningun objeto seleccionado");
                }
                if (string.IsNullOrWhiteSpace(descripcion))
                {
                    throw new ArgumentException("Esta descripcion no es valida");
                }
                CasaElectronica.EditarTarea(elemento, descripcion);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static void EliminarTarea(object objeto)
        {
            if(objeto is null)
            {
                throw new NullReferenceException("No hay ninguna tarea seleccionada");
            }
            CasaElectronica.EliminarTarea(objeto);
        }

        public static void Exportar(string ruta)
        {
            CasaElectronica.Exportar(ruta);
        }

        public static void Importar()
        {
            try
            {
                CasaElectronica.Importar();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Guardar()
        {
            try
            {
                CasaElectronica.Guardar();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Cargar()
        {
            try
            {
                CasaElectronica.Cargar();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
