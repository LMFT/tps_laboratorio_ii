using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Componente : Producto
    {
        private double capacidad;
        private string unidadMedicion;

        public Componente() : base()
        {
            capacidad = 0;
            unidadMedicion = string.Empty;
        }

        public Componente(string nombre, decimal precio,string marca,double capacidad, string unidadMedicion) 
        : base(nombre, precio,marca)
        {
            this.capacidad = capacidad;
            this.unidadMedicion = unidadMedicion;
        }

        internal Componente(ComponenteInterno componente)
        {
            ultimoId = componente.UltimoId;
            id = componente.Id;
            descripcion = componente.Descripcion;
            precio = componente.Precio;
            marca = componente.Marca;
            capacidad = componente.Capacidad;
            unidadMedicion = componente.UnidadMedicion;
        }

        public double Capacidad
        {
            get
            {
                return capacidad;
            }
        }

        public string UnidadMedicion
        {
            get
            {
                return unidadMedicion;
            }
        }

        internal static int UltimoId
        {
            get
            {
                return ultimoId;
            }
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"Capacidad: {capacidad}{unidadMedicion}");
            return sb.ToString();
        }

    }
}
