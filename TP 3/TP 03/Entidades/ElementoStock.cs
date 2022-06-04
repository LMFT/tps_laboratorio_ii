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

        public ElementoStock(T producto, int cantidad)
        {
            this.producto = producto;
            this.cantidad = cantidad;
        }

        public ElementoStock(KeyValuePair<T, int> par) 
        : this(par.Key,par.Value)
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
                return producto.Descripcion;
            }
        }

        public decimal Precio
        {
            get
            {
                return (decimal)producto.Precio;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }
        }

        public static bool operator ==(ElementoStock<T> elemento, T item)
        {
                if(elemento.producto == item)
                {
                    return true;
                }
            return false;
        }

        public static bool operator !=(ElementoStock<T> elemento, T item)
        {
            return !(elemento == item);
        }

        public override bool Equals(object obj)
        {
            return obj is T producto && this == producto;
        }

        public override int GetHashCode()
        {
            return producto.GetHashCode();
        }

        /// <summary>
        /// Convierte el elemento en un par clave valor
        /// </summary>
        /// <param name="usarCantidadMinima">Indica si se debería utilizar la cantidad actual o minima de unidades 
        /// de producto en el inventario</param>
        /// <returns></returns>
        public KeyValuePair<T, int> APar()
        {
            return KeyValuePair.Create(producto, cantidad);
        }

        public bool ModificarCantidad(int variacion)
        {
            bool resultado = (variacion < 0 && cantidad + variacion >= 0) || variacion >= 0;
            if (resultado)
            {
                cantidad += variacion;
            }
            return resultado;
        }
    }
}