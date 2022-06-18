using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Interfaces;

namespace Entidades
{
    public class Proveedor : Persona, ICargar<Proveedor>
    {
        private List<Producto> productos;
        private bool estaActivo;

        public Proveedor() : base() 
        {
            productos = new List<Producto>();
            estaActivo = true;
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

        private Proveedor(object[] valores)
        {
            nombre = valores[0].ToString();
            apellido = valores[1].ToString();
            dni = (int)valores[2];
            productos = GetProductos(CasaElectronica.BuscarProducto, valores[3]);
            if(valores[4].ToString() == "1")
            {
                estaActivo = true;
            }
            else
            {
                estaActivo = false;
            }
        }

        private static List<Producto> GetProductos(DelegadoBuscar<Producto> delegadoBuscar, object ids)
        {
            if(ids is null || delegadoBuscar is null)
            {
                throw new ArgumentException("Uno de los campos requeridos para la carga de productos es invalido");
            }
            string[] idsStr = ids.ToString().Split(',');
            List<Producto> lista = new List<Producto>();
            foreach(string id in idsStr)
            {
                if(int.TryParse(id, out int idInt))
                {
                    lista.Add(delegadoBuscar(idInt));
                }
            }
            return lista;
        }


        internal List<Producto> Productos
        {
            get
            {
                return productos;
            }
        }

        public bool EstaActivo
        {
            get
            {
                return estaActivo;
            }
        }

        public Proveedor Cargar(object[] valores)
        {
            return new Proveedor(valores);
        }

        internal override string ActualizarValores()
        {
            StringBuilder sb = new StringBuilder(base.ActualizarValores());
            for(int i=0;i<productos.Count;i++)
            { 
                sb.Append(productos[i].Id);
                if(i != productos.Count - 1)
                {
                    sb.Append(',');
                }
            }
            sb.AppendLine("");
            if (estaActivo)
            {
                sb.AppendLine($"ESTA_ACTIVO = 1");
            }
            else
            {
                sb.AppendLine($"ESTA_ACTIVO = 0");
            }
            return sb.ToString();
        }

        internal override string GetValores()
        {
            string productos = "";
            foreach(Producto producto in Productos)
            {
                productos += $"{producto.Id},";
            }
            productos = productos.Remove(productos.Length - 1);
            return base.GetValores() + $"{productos}";
        }
    }
}
