using Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProveedorInterno : Persona, IObtener<Proveedor>
    {
        private List<Producto> productos;

        public ProveedorInterno()
        {
            nombre = string.Empty;
            apellido = string.Empty;
            dni = 0;
            productos = new List<Producto>();
        }

        public ProveedorInterno(Proveedor proveedor)
        {
            nombre = proveedor.Nombre;
            apellido = proveedor.Apellido;
            dni = proveedor.Dni;
            productos = proveedor.Productos;
        }

        public new string Nombre { get => nombre; set => nombre = value; }
        public new string Apellido { get => apellido; set => apellido = value; }
        public new int Dni { get => dni; set => dni = value; }
        public List<Producto> Productos { get => productos; set => productos = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public Proveedor Obtener()
        {
            if(this is null)
            {
                throw new NullReferenceException("Se produjo un fallo al cargar este proveedor");
            }
            return new Proveedor(this);
        }
    }
}
