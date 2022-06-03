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

        public Proveedor(string nombre, string apellido, int dni, List<Producto> productos) : base(nombre, apellido, dni)
        {
            this.productos = new List<Producto>(productos);
        }

        public  Proveedor(string nombre, string apellido, int dni) : this(nombre, apellido, dni, null)
        {

        }
    }
}
