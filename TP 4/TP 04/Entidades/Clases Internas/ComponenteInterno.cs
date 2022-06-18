using Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ComponenteInterno : Producto, IObtener<Componente>
    {
        private double capacidad;
        private string unidadMedicion;
        private int cantidad;
        public ComponenteInterno()
        {
            id = 0;
            descripcion = string.Empty;
            precio = 0;
            unidadMedicion = string.Empty;
            capacidad = 0;
        }

        public ComponenteInterno(Componente componente)
        {
            id = componente.Id;
            descripcion = componente.Descripcion;
            precio = componente.Precio;
            marca = componente.Marca;
            capacidad = componente.Capacidad;
            unidadMedicion = componente.UnidadMedicion;
        }

        public ComponenteInterno(Componente componente, int cantidad) : this(componente)
        {
            this.cantidad = cantidad;
        }

        public new int Id { get => id; set => id = value; }
        public new string Descripcion { get => descripcion; set => descripcion = value; }
        public new decimal Precio { get => precio; set => precio = value; }
        public new string Marca { get => marca; set => marca = value; }
        public double Capacidad { get => capacidad; set => capacidad = value; }
        public string UnidadMedicion { get => unidadMedicion; set => unidadMedicion = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int UltimoId { get => ultimoId; set => ultimoId = value; }

        public Componente Obtener()
        {
            return new Componente(this);
        }
    }
}
