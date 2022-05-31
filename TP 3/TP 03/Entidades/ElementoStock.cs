using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La finalidad de esta clase es poder reemplazar los pares clave-valor de un diccionario por un elemento que pueda 
    /// ser ingresado a una lista. Tambien se le dió funcionalidad para poder revertir este proceso y recuperar el par 
    /// original
    /// </summary>
    public class ElementoStock<T> where T : Producto
    {
        private T producto;
        private int cantidad;
        private int cantidadMinima;

        public ElementoStock(T producto, int cantidad)
        {
            this.producto = producto;
            this.cantidad = cantidad;
            cantidadMinima = 1;
        }
        public ElementoStock(T producto, int cantidad, int cantidadMinima) 
        :this(producto,cantidad)
        {
            this.producto = producto;
            this.cantidad = cantidad;
            this.cantidadMinima = cantidadMinima;
        }

        public ElementoStock(KeyValuePair<T, int> par, int cantidadMinima) 
        : this(par.Key,par.Value, cantidadMinima)
        {
            
        }

        public int Id
        {
            get
            {
                return producto.Id;
            }
        }

        public string Nombre
        {
            get
            {
                return producto.Nombre;
            }
        }

        public decimal Precio
        {
            get
            {
                return (decimal)producto.Precio;
            }
        }

        public double Cantidad
        {
            get
            {
                return cantidad;
            }
        }

        public int CantidadMinima
        {
            get
            {
                return cantidadMinima;
            }
        }

        /// <summary>
        /// Convierte el elemento en un par clave valor
        /// </summary>
        /// <param name="usarCantidadMinima">Indica si se debería utilizar la cantidad actual o minima de unidades 
        /// de producto en el inventario</param>
        /// <returns></returns>
        public KeyValuePair<T, int> APar(bool usarCantidadMinima)
        {
            if (usarCantidadMinima)
            {
                return KeyValuePair.Create(producto, this.cantidadMinima);
            }
            return KeyValuePair.Create(producto, cantidad);
        }
    }
}