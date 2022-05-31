using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Cable : Producto
    {
        private double seccion;
        private bool dobleAislacion;
        public Cable(string nombre, decimal precio,string marca, double seccion, bool dobleAislacion)
        : base(nombre, precio, marca)
        {
            this.seccion = seccion;
            this.dobleAislacion = dobleAislacion;
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

