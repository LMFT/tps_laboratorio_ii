using Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CableInterno : Producto, IObtener<Cable>
    {
        private double seccion;
        private bool dobleAislacion;
        private int cantidad;

        public CableInterno()
        {
            id = 0;
            descripcion = string.Empty;
            precio = 0;
            dobleAislacion = false;
            seccion = 0;
        }

        public CableInterno(Cable cable)
        {
            id = cable.Id;
            descripcion = cable.Descripcion;
            precio = cable.Precio;
            marca = cable.Marca;
            seccion = cable.Seccion;
            dobleAislacion = cable.DobleAislacion;;
        }

        public CableInterno(Cable cable, int cantidad) : this(cable)
        {
            this.cantidad = cantidad;
        }

        public new int Id { get => id; set => id = value; }
        public new string Descripcion { get => descripcion; set => descripcion = value; }
        public new decimal Precio { get => precio; set => precio = value; }
        public new string Marca { get => marca; set => marca = value; }
        public double Seccion { get => seccion; set => seccion = value; }
        public bool DobleAislacion { get => dobleAislacion; set => dobleAislacion = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int UltimoId { get => ultimoId; set => ultimoId = value; }

        public Cable Obtener()
        {
            return new Cable(this);
        }
    }
}
