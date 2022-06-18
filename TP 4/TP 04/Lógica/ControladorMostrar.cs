using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

using Logica.Login;
using Logica.MenuPrincipal;

using Mostrar;

namespace Logica.Mostrar
{
    public static class ControladorMostrar
    {

        public static ImmutableList<Usuario> Empleados
        {
            get
            {
                return CasaElectronica.Personal;
            }
        }

        public static ImmutableList<ElementoStock<Producto>> Inventario
        {
            get 
            {
                ImmutableList<ElementoStock<Producto>> lista = ImmutableList.Create<ElementoStock<Producto>>();
                foreach(KeyValuePair<Producto,int> par in CasaElectronica.Stock)
                {
                    lista = lista.Add(new ElementoStock<Producto>(par));
                }
                return lista;
            }
        }

        public static ImmutableList<Proveedor> Proveedores
        {
            get
            {
                return CasaElectronica.Proveedores;
            }
        }

        public static bool UsuarioEsAdmin
        {
            get
            {
                return ControladorLogin.UsuarioLogeado.Permisos > 0;
            }
        }
        /// <summary>
        /// Permite eliminar un elemento de su respectivo listado
        /// </summary>
        /// <param name="id">Id del elemento a eliminar</param>
        /// <param name="mostrarInfo">Determina qué tipo de elemento es para buscarlo en la coleccion correspondiente
        /// </param>
        /// <returns>Retorna true si pudo eliminar el elemento, de lo contrario false</returns>
        public static bool Eliminar(int id, MostrarInfo mostrarInfo)
        {
            switch (mostrarInfo)
            {
                case MostrarInfo.Empleado:
                    Usuario usuario = CasaElectronica.BuscarUsuario(id);
                    return CasaElectronica.Despedir(usuario);      
                default:
                    Producto insumo = CasaElectronica.BuscarProducto(id);
                    return CasaElectronica.EliminarDeStock(insumo);
            }
        }

        /// <summary>
        /// Permite reponer el stock de un elemento. Automáticamente lo repone hasta 2 veces la cantidad minima.
        /// </summary>
        /// <param name="elemento">Elemento a reponer</param>
        public static void RellenarStock(object elemento)
        {
            ElementoStock<Producto> producto = elemento as ElementoStock<Producto>;
            if(producto is not null)
            {
                CasaElectronica.ReponerStock(producto);
            }
        }
        /// <summary>
        /// Repone una cantidad de unidades de un elemento en stock
        /// </summary>
        /// <param name="elemento">Elemento a reponer</param>
        /// <param name="cantidad">Cantidad a añadir</param>
        public static void RellenarStock(object elemento, int cantidad)
        {
            ElementoStock<Producto> producto = elemento as ElementoStock<Producto>;
            if (producto is not null)
            {
                CasaElectronica.ReponerStock(producto,cantidad);
            }
        }

        public static bool NotificarFaltante(object elemento, DelegadoNotificar delegadoNotificar)
        {
            if(elemento is Producto producto)
            {
                delegadoNotificar($"Se requiere rellenar el stock del siguiente producto:" + 
                                  $"ID:{producto.Id} - Nombre: {producto.Descripcion}");
                return true;
            }
            return false;
        }

        public static bool NotificarFaltante(object elemento)
        {
            return NotificarFaltante(elemento, ControladorMenuPrincipal.NuevaTarea);
        }
    }
}
