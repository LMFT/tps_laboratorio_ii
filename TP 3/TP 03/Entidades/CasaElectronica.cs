﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class CasaElectronica
    {
        private static List<Usuario> personal;
        private static Dictionary<Producto, int> stock;
        private static Dictionary<Producto, int> stockMinimo;
        private static List<Operacion> historial;

        static CasaElectronica()
        {
            historial = new List<Operacion>();
            HardcodearPersonal();
            HardcodearStock();
        }
        /// <summary>
        /// Retorna la lista de personal del bar de forma inmutable
        /// </summary>
        public static ImmutableList<Usuario> Personal
        {
            get
            {
                return ImmutableList.Create(personal.ToArray());
            }
        }
        /// <summary>
        /// Retorna el stock del bar de forma inmutable
        /// </summary>
        public static ImmutableDictionary<Producto, int> Stock
        {
            get
            {
                ImmutableDictionary<Producto, int> diccionario = ImmutableDictionary.Create<Producto, int>();
                diccionario = diccionario.AddRange(stock);
                return diccionario;
            }
        }
        /// <summary>
        /// Hardcodea el listado de personal
        /// </summary>
        private static void HardcodearPersonal()
        {
            int[] dni = { 23345678, 33445566 };
            string[] nombres = { "Agustin", "Carla" };
            string[] apellidos = { "Ramirez", "Fernandez" };
            string[] passwords = { "Contra1", "Contra2" };

            personal = new List<Usuario>();
            for (int i = 0; i < nombres.Length; i++)
            {
                Usuario usuario = new Usuario(nombres[i], apellidos[i], dni[i], (Permisos)i,
                    Usuario.GenerarNombreUsuario(nombres[i], apellidos[i]), passwords[i]);
                personal += (usuario);
            }
        }

        /// <summary>
        /// Hardcodea el stock del bar
        /// </summary>
        private static void HardcodearStock()
        {
            string[] nombres = { "Cable", "Cable de doble aislacion", "Resistencia", "Resistencia", "Resistencia" };
            decimal[] precios = { 200M, 500M, 60M, 60M, 60M };
            string[] marcas = { "Volteck", "Backer"};
            int[] cantidades = { 2000, 1000, 75, 95, 40};
            int[] cantidadesMinimas = { 1000, 500, 50, 50, 50 };
            double[] secciones = { 1.5, 6 };
            double[] capacidades = { 100,200,500};
            string unidadMedida = "Ω";//Los valores de resistencia se representan con la letra Omega

            stock = new Dictionary<Producto, int>();
            stockMinimo = new Dictionary<Producto, int>();

            for (int i = 0; i < nombres.Length; i++)
            {
                Producto producto;
                if (i < 2)
                {
                    producto = new Cable(nombres[i], precios[i], marcas[0], secciones[i],i%2==1);

                }
                else
                {
                    producto = new Componente(nombres[i], precios[i], marcas[1], capacidades[i-2],unidadMedida);
                }
                stock.Add(producto, cantidades[i]);
                stockMinimo.Add(producto, cantidadesMinimas[i]);
            }
        }
        /// <summary>
        /// Busca un usuario en base al nombre de usuario registrado en la app
        /// </summary>
        /// <param name="nombreUsuario">Nombrea buscar en la lista</param>
        /// <returns>El usuario asociado al nombre de usuario, o null si no encuentra una 
        /// coincidencia</returns>
        public static Usuario BuscarUsuario(string nombreUsuario)
        {
            return Usuario.BuscarPorNombreDeUsuario(personal, nombreUsuario);
        }
        /// <summary>
        /// Busca un usuario en base a su numero de ID
        /// </summary>
        /// <param name="id">ID del usuario a buscar</param>
        /// <returns>El usuario asociado al ID recibido, o null si no encuentra una 
        /// coincidencia</returns>
        public static Usuario BuscarUsuario(int id)
        {
            return Usuario.BuscarPorId(personal, id);
        }
        /// <summary>
        /// Obtiene el primer usuario que sea empleado o administrador, en base a la condicion recibida
        /// por parametro
        /// </summary>
        /// <param name="esAdministrador">Determina si el usuario a obtener es un administrador o no</param>
        /// <returns>EL primer usuario encontrado que cumple con el criterio recibido, o null si nungun empleado 
        /// cumple con dicho criterio</returns>

        public static Usuario ObtenerUsuario(bool esAdministrador)
        {
            return Usuario.Obtener(personal, esAdministrador);
        }
        /// <summary>
        /// Valida que haya stock de un consumible, o de los ingredientes para prepararlo
        /// </summary>
        /// <param name="producto">Consumible a verificar</param>
        /// <returns>true en caso de que haya suficientes ingredientes o consumibles, de lo contrario false</returns>
        public static bool HayStock(Producto producto, double cantidad)
        {
            if(stock == producto)
            {
                return stock[producto] > cantidad;
            }
            return false;
        }
        public static bool HayStock(Producto producto)
        {
            return HayStock(producto,1);
        }

        /// <summary>
        /// Busca un producto en el stock
        /// </summary>
        /// <param name="id">ID del producto a buscar</param>
        /// <returns>Producto cuyo ID coincide con el parametro, o null si no encuentra el ID</returns>
        public static Producto BuscarProducto(int id)
        {
            return Producto.BuscarPorId(Stock.Keys.ToList(),id);
        }
        /// <summary>
        /// Permite dar de alta un usuario en nuestro sistema
        /// </summary>
        /// <param name="usuario">Usuario a dar de alta</param>
        /// <returns>true si el usuario pudo agregarse correctamente, o false si ya existe el usuario</returns>
        public static bool AltaEmpleado(Usuario usuario)
        {
            if(usuario is not null)
            {
                personal += usuario;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Añade un producto con una determinada cantidad al stock
        /// </summary>
        /// <param name="producto">Producto a añadir</param>
        /// <param name="cantidad">Cantidad de unidades del producto</param>
        /// <returns>Retorna true si pudo añadir el elemento stock</returns>
        private static bool AgregarAStock(Producto producto, int cantidad)
        {
            if (stock == producto)
            {
                return false;
            }
            stock.Add(producto, cantidad);
            return true;
        }
        /// <summary>
        /// Añade un producto con una determinada cantidad al stock, determinando la cantidad minima que debe existir de este
        /// producto
        /// </summary>
        /// <param name="producto">Producto a añadir</param>
        /// <param name="cantidad">Cantidad de unidades del producto</param>
        /// <param name="cantidadMinima">Cantidad minma de unidades del producto que deberia haber</param>
        /// <returns>Retorna true si pudo añadir el elemento stock</returns>
        public static bool AgregarAStock(Producto producto, int cantidad, int cantidadMinima)
        {
            if (AgregarAStock(producto, cantidad))
            {
                stockMinimo.Add(producto,cantidadMinima);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Valida si la cantidad de stock de un producto es cercana a la cantidad minima de producto 
        /// que deberia haber en stock 
        /// </summary>
        /// <param name="producto">Producto a verificar</param>
        /// <returns>Retorna true cuando la cantidad de producto disponible es inferior al 125% de la cantidad minima
        /// (De tener una cantidad minima de 20 unidades, retornará true si la cantidad actual es inferior a 25)</returns>
        public static bool VerificarStockMinimo(Producto producto)
        {
            return stock[producto] / stockMinimo[producto] < 1.25;
        }
        /// <summary>
        /// Rellena el stock de un producto a 2 veces su cantidad mínima
        /// </summary>
        /// <param name="producto">Producto a reponer en stock</param>
        public static void ReponerStock(ElementoStock<Producto> elementoInventario)
        {
            if(elementoInventario is not null)
            {
                KeyValuePair<Producto, int> par = elementoInventario.APar(false);
                stock[par.Key] = stockMinimo[par.Key]*2;
            }
        }
        /// <summary>
        /// Repone una cantidad de unidades de un producto al stock
        /// </summary>
        /// <param name="elementoInventario">Producto a reponer</param>
        /// <param name="cantidad">Cantidad de unidades a agregar</param>
        public static void ReponerStock(ElementoStock<Producto> elementoInventario, int cantidad)
        {
            KeyValuePair<Producto, int> par = elementoInventario.APar(false);
            stock[par.Key] += cantidad;
        }
        /// <summary>
        /// Obtiene la cantidad mínima de unidades que debería haber de un producto en stock
        /// </summary>
        /// <param name="producto">Producto del cual queremos saber la cantidad minimad e unidades</param>
        /// <returns>La cantidad mínima de unidades del producto, o -1 si no se encuentra el producto</returns>
        public static int CantidadMinima(Producto producto)
        {
            if(stockMinimo == producto)
            {
                return stockMinimo[producto];
            }
            return -1;
        }
        /// <summary>
        /// Elimina un producto del stock
        /// </summary>
        /// <param name="producto">Producto a eliminar</param>
        /// <returns><see langword="true"/> si el producto pudo removerse, <see langword="false"/>
        /// si el producto no pudo encontrarse</returns>
        public static bool EliminarDeStock(Producto producto)
        {
            return stock - producto;
        }
        /// <summary>
        /// Elimina a un usuario del listado de personal del bar
        /// </summary>
        /// <param name="usuario">Usuario a eliminar</param>
        /// <returns>Retorna true si pudo eliminarse al usuario de la lista, de lo contrario false</returns>
        public static bool Despedir(Usuario usuario)
        {
            return personal - usuario;
        }
        
        /// <summary>
        /// Calcula el precio total de la mesa, incluyendo estacionamiento
        /// </summary>
        /// <param name="indiceMesa"></param>
        /// <returns></returns>
        public static decimal CalcularPrecioTotal(int indiceMesa)
        {
            decimal total = 0;
            
            return total;
        }

        /// <summary>
        /// Añade una nueva operacion al historial de operaciones
        /// </summary>
        /// <param name="indiceMesa">Indice de la mesa sobre la cual crear la operacion</param>
        /// <returns>True si pudo crearse una nueva operacion, de lo contrario false</returns>
        public static bool NuevaOperacion(int indiceMesa)
        {
            return false;
        }
    }
}