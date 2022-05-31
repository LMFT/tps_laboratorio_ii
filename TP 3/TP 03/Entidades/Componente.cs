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

        public Componente(string nombre, decimal precio,string marca,double capacidad, string unidadMedicion) 
        : base(nombre, precio,marca)
        {
            this.capacidad = capacidad;
            this.unidadMedicion = unidadMedicion;
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
