using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Proveedor : Persona
    {
        private List<Producto> productos;

        public Proveedor() : base() 
        {
            productos = new List<Producto>();
        }
        public Proveedor(string nombre, string apellido, int dni, List<Producto> productos) : base(nombre, apellido, dni)
        {
            this.productos = new List<Producto>(productos);
        }

        public  Proveedor(string nombre, string apellido, int dni) : this(nombre, apellido, dni, null)
        {

        }
        internal Proveedor(ProveedorInterno proveedor)
        {
            nombre = proveedor.Nombre;
            apellido = proveedor.Apellido;
            dni = proveedor.Dni;
            productos = proveedor.Productos;
        }

        public static bool operator ==(List<Proveedor> lp, Proveedor p)
        {
            foreach(Proveedor proveedor in lp)
            {
                if(p.dni == proveedor.dni) 
                { 
                    return true; 
                }
            }
            return false;
        }

        public static bool operator !=(List<Proveedor> lp, Proveedor p)
        {
            return !(lp == p);
        }


        internal List<Producto> Productos
        {
            get
            {
                return productos;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Proveedor proveedor && proveedor == this;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
