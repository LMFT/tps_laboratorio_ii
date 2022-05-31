using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

using Logica.MenuPrincipal;

namespace Logica.AgregarPedidos
{
    public static class ControladorAgregar
    {
        private static List<ElementoStock<Producto>> inventario;
        private static List<Producto> pedidos;

        static ControladorAgregar()
        {
            inventario = new List<ElementoStock<Producto>>();
            pedidos = new List<Producto>();
        }

        public static bool UsuarioEsAdmin
        {
            get
            {
                return ControladorMenuPrincipal.UsuarioEsAdmin;
            }
        }

        public static ImmutableList<ElementoStock<Producto>> Inventario
        {
            get
            {
                return ImmutableList.Create(inventario.ToArray());
            }
        }

        /// <summary>
        /// Añade un nuevo pedido al listado de pedidos, indicando la cantidad de unidades requeridas
        /// </summary>
        /// <param name="indice">Índice del producto a añadir</param>
        /// <param name="cantidad">Cantidades de unidades a agregar al pedido</param>
        /// <returns>Este metodo retorna true cuando pudo agregar correctamente la cantidad de unidades
        /// al listado de pedidos. De lo contraio retorna false</returns>
        public static bool AgregarPedido(int indice, int cantidad)
        {
            List<Producto> productos = CasaElectronica.Stock.Keys.ToList();
            if (indice >= 0 && indice < productos.Count && cantidad > 0)
            {
                Producto producto = productos[indice];
                if (PrepararPedido(producto))
                {
                    pedidos.Add(producto);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Elimina una cantidad de unidades de un pedido del listado de pedidos
        /// </summary>
        /// <param name="indice">Indice del pedido a eliminar</param>
        /// <param name="cantidad">Cantidad a eliminar. De superar la cantidad de pedidos, elimina el pedido de la lista</param>
        public static void EliminarPedido(int indice, int cantidad)
        {
            ElementoStock<Producto> auxiliar;
            if (indice >= 0 && indice < pedidos.Count && cantidad > 0)
            {
                foreach(ElementoStock<Producto> elemento in inventario)
                {
                    auxiliar = elemento;
                    var par = elemento.APar(false);
                    if(pedidos[indice] == par.Key)
                    {
                        if (cantidad > par.Value)
                        {
                            pedidos.RemoveAt(indice);
                        }
                        else
                        {
                            auxiliar = new ElementoStock<Producto>(par,auxiliar.CantidadMinima);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Prepara un pedido, consumiendo elementos del inventario para prepararlo
        /// </summary>
        /// <param name="producto">Consumible a preparar</param>
        /// <returns>Retorna true si el pedido pudo prepararse correctamente. De lo contrario false</returns>
        public static bool PrepararPedido(Producto producto)
        {
            if(producto is not null && CasaElectronica.HayStock(producto))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Limpia el listado de pedidos para reutilizar la ventana
        /// </summary>
        public static void LimpiarPedidos()
        {
            pedidos.Clear();
        }
    }
}
