using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Cable))]
    [XmlInclude(typeof(CableInterno))]
    [XmlInclude(typeof(Componente))]
    [XmlInclude(typeof(ComponenteInterno))]
    public class Producto
    {
        protected static int ultimoId;
        protected int id;
        protected decimal precio;
        protected string descripcion;
        protected string marca;

        static Producto()
        {
            ultimoId = 0;
        }

        public Producto()
        {
            id = 0;
            precio = 0;
            descripcion = String.Empty;
            marca = String.Empty;
        }

        public Producto(string nombre, decimal precio, string marca)
        {
            ultimoId++;
            id = ultimoId;
            this.descripcion = nombre;
            this.precio = precio;
            this.marca = marca;
        }

        public int Id
        {
            get 
            { 
                return id; 
            }
        }

        public string Descripcion
        {
            get 
            { 
                return descripcion; 
            }
        }

        public decimal Precio
        {
            get
            {
                return precio;
            }
        }

        public string Marca
        {
            get
            {
                return marca;
            }
        }

        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {descripcion}");
            sb.AppendLine($"Precio: {precio}");
            return sb.ToString();
        }

        public static explicit operator int(Producto p)
        {
            return p.id;
        }

        public static explicit operator decimal(Producto p)
        {
            return p.precio;
        }

        public static bool operator ==(Producto p1, Producto p2)
        {
            return p1.id == p2.id;
        }

        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }

        public static decimal operator +(Producto p, decimal d)
        {
            return p.precio + d;
        }

        public static decimal operator +(decimal d, Producto p)
        {
            return p + d;
        }
        public static bool operator ==(Dictionary<Producto, int> d, Producto p)
        {
            if (d is not null && p is not null)
            {
                foreach(var par in d)
                {
                    if(par.Key == p)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator !=(Dictionary<Producto, int> d, Producto p)
        {
            return !(d == p);
        }

        public static bool operator ==(List<Producto> lp, Producto p)
        {
            if (lp is not null && p is not null)
            {
                foreach (Producto producto in lp)
                {
                    if(producto == p)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool operator -(Dictionary<Producto, int> d,Producto p)
        {
            if(d is not null)
            {
                return d.Remove(p);
            }
            return false;
        }

        public static bool operator !=(List<Producto> lp, Producto p)
        {
            return !(lp == p);
        }


        public override bool Equals(object obj)
        {
            if(obj is Producto p)
            {
                return this.id == p.id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override string ToString()
        {
            if(descripcion is not null)
            {
                return descripcion;
            }
            return string.Empty;
        }
        /// <summary>
        /// Busca un producto en una lista utilizando su id 
        /// </summary>
        /// <param name="lista">Lista de productos</param>
        /// <param name="id">Id a buscar</param>
        /// <returns>El producto cuyo id coincide con el recibido por parametro, o null si
        /// ningun id coincide con el producto</returns>
        public static Producto BuscarPorId(List<Producto> lista,int id)
        {
            if(lista is not null)
            {
                foreach (Producto producto in lista)
                {
                    if (producto.id == id)
                    {
                        return producto;
                    }
                }
            }
            return null;
        }
    }
}
