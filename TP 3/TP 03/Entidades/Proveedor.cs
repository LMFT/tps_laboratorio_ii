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

        internal List<Producto> Productos
        {
            get
            {
                return productos;
            }
        }
    }
}
