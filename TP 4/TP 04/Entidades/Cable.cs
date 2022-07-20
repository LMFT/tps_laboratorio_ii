using Interfaces;

using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Cable : Producto, ICargar<Cable>
    {
        private double seccion;
        private bool dobleAislacion;

        public Cable() : base()
        {
            seccion = 0;
            dobleAislacion = false;
        }

        public Cable(string nombre, decimal precio,string marca, double seccion, bool dobleAislacion)
        : base(nombre, precio, marca)
        {
            this.seccion = seccion;
            this.dobleAislacion = dobleAislacion;
        }

        internal Cable(CableInterno cable)
        {
            ultimoId = cable.UltimoId;
            id= cable.Id;
            descripcion = cable.Descripcion;
            precio = cable.Precio;
            marca = cable.Marca;
            seccion = cable.Seccion;
            dobleAislacion = cable.DobleAislacion;
        }

        private Cable(object[] elementos)
        {
            id = (int)elementos[0];
            if(ultimoId < id)
            {
                ultimoId = id;
            }
            descripcion = (string)elementos[1];
            precio = (decimal)elementos[2];
            marca = (string)elementos[3];
            seccion = (double)elementos[4];
            dobleAislacion = (bool)elementos[5];
        }

        public double Seccion
        {
            get
            {
                return seccion;
            }
        }

        public bool DobleAislacion
        {
            get
            {
                return dobleAislacion;
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
            sb.AppendLine($"{base.Mostrar()}");
            sb.AppendLine($"Seccion: {seccion}");
            sb.Append($"Doble Aislacion:");
            if (dobleAislacion)
            {
                sb.AppendLine("Si");
            }
            else
            {
                sb.AppendLine("No");
            }

            return sb.ToString();
        }

        public override string Descripcion
        {
            get
            {
                if (dobleAislacion)
                {
                    return $"{descripcion}, {seccion} mm";
                }
                    return $"{descripcion}, {seccion} mm";
            }
        }

        public override string ToString()
        {
            return Descripcion;
        }

        public Cable Cargar(object[] elementos)
        {
            if(elementos.Length >= 7)
            {
                return new Cable(elementos);
            }
            return null;
        }

        internal override string ActualizarValores()
        {
            StringBuilder sb = new StringBuilder(base.ActualizarValores());
            sb.AppendLine($"CAMPO_1 = {seccion}");
            string dobleAislacion = this.dobleAislacion ? "1" : "0";
            sb.AppendLine($"CAMPO_2 = {dobleAislacion}");
            return sb.ToString();
        }

        internal override string GetValores()
        {
            return base.GetValores() + $"{seccion},{dobleAislacion}";
        }
    }
}

