using Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Componente : Producto, ICargar<Componente>
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

        private Componente(object[] elementos)
        {
            id = (int)elementos[0];
            if(ultimoId < id)
            {
                ultimoId = id;
            }
            descripcion = (string)elementos[1];
            precio = (decimal)elementos[2];
            marca = (string)elementos[3];
            capacidad = (double)elementos[4];
            unidadMedicion = (string)elementos[5];
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

        public override string Descripcion 
        { 
            get 
            { 
                return $"{descripcion} x {capacidad} {unidadMedicion}"; 
            } 
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"Capacidad: {capacidad}{unidadMedicion}");
            return sb.ToString();
        }

        public override string ToString()
        {
            return Descripcion;
        }

        public Componente Cargar(object[] elementos)
        {
            if(elementos.Length >= 7)
            {
                return new Componente(elementos);
            }
            return null;
        }

        internal override string ActualizarValores()
        {
            StringBuilder sb = new StringBuilder(base.ActualizarValores());
            sb.AppendLine($"CAMPO_1 = {capacidad}");
            sb.AppendLine($"CAMPO_2 = {unidadMedicion}");
            return sb.ToString();
        }

        internal override string GetValores()
        {
            return base.GetValores() + $"{capacidad},{unidadMedicion}";
        }
    }
}
