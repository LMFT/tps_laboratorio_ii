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
        private static List<ElementoStock<Producto>> pedidosCliente;
        private static List<Producto> productosProveedor;

        static ControladorAgregar()
        {
            inventario = new List<ElementoStock<Producto>>();
            pedidosCliente = new List<ElementoStock<Producto>>();
            productosProveedor = new List<Producto>();
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

        internal static List<Producto> Productos
        {
            get
            {
                return productosProveedor;
            }
        }

        /// <summary>
        /// Añade un nuevo pedido al listado de pedidos, indicando la cantidad de unidades requeridas
        /// </summary>
        /// <param name="indice">Índice del producto a añadir</param>
        /// <param name="cantidad">Cantidades de unidades a agregar al pedido</param>
        /// <returns>Este metodo retorna true cuando pudo agregar correctamente la cantidad de unidades
        /// al listado de pedidos. De lo contraio retorna false</returns>
        public static bool NuevoPedido(object elemento, int cantidad)
        {
            if(elemento is not null && elemento is Producto producto)
            {
                foreach(var item in inventario)
                {
                    if(item == producto && item.Cantidad >= cantidad)
                    {
                        PrepararPedido(producto,cantidad);
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Elimina una cantidad de unidades de un pedido del listado de pedidos
        /// </summary>
        /// <param name="elemento">Elemento a eliminar</param>
        /// <param name="cantidad">Cantidad a eliminar. De superar la cantidad de items pedidos anteriormente, 
        /// elimina el pedido de la lista</param>
        public static bool EliminarPedido(object elemento, int cantidad)
        {
            if (elemento is not null && elemento is Producto producto)
            {
                foreach (var item in pedidosCliente)
                {
                    if (item == producto)
                    {
                        if(cantidad >= item.Cantidad)
                        {
                            return pedidosCliente.Remove(item);
                        }
                        return item.ModificarCantidad(cantidad*-1);
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Prepara un pedido, consumiendo elementos del inventario para prepararlo
        /// </summary>
        /// <param name="producto">Consumible a preparar</param>
        /// <returns>Retorna true si el pedido pudo prepararse correctamente. De lo contrario false</returns>
        public static bool PrepararPedido(Producto producto, int cantidad)
        {
            if(producto is not null && CasaElectronica.HayStock(producto))
            {
                ElementoStock<Producto> pedido = new ElementoStock<Producto>(producto, cantidad);
                pedidosCliente.Add(pedido);
                CasaElectronica.RetirarDeStock(producto, cantidad);

            }
            return false;
        }
        /// <summary>
        /// Limpia el listado de pedidos para reutilizar la ventana
        /// </summary>
        public static void LimpiarPedidos()
        {
            pedidosCliente.Clear();
        }

        public static void AgregarProducto(object elemento)
        {
            if(elemento is ElementoStock<Producto> elementoStock)
            {
                productosProveedor.Add(elementoStock.APar().Key);
            }
        }

        public static void EliminarProducto(object elemento)
        {
            if (elemento is ElementoStock<Producto> elementoStock)
            {
                Producto producto = elementoStock.APar().Key;
                if(productosProveedor == producto)
                {
                    productosProveedor.Remove(elementoStock.APar().Key);
                }
            }
        }

        public static void LimpiarProductos()
        {
            productosProveedor.Clear();
        }
    }
}
