using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Cable : Producto
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
    }
}

