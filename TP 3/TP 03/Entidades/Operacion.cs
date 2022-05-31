using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operacion
    {
        private static int ultimoId;
        private int id;
        private decimal total;

        static Operacion()
        {
            ultimoId = 0;
        }

        public Operacion(decimal total)
        {
            id = ++ultimoId;
            this.total = total;
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public decimal Total
        {
            get
            {
                return total;
            }
        }

        public static bool operator ==(Operacion o1, Operacion o2)
        {
            if(o1 is not null && o2 is not null)
            {
                return o1.id == o2.id;
            }
            return false;
        }

        public static bool operator !=(Operacion o1, Operacion o2)
        {
            return !(o1 == o2);
        }

        public static bool operator +(List<Operacion> lo, Operacion o)
        {
            if(lo is not null && o is not null)
            {
                lo.Add(o);
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            if(obj is Operacion operacion && this == operacion)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Numero de operacion: {id}");
            return sb.ToString();
        }
    }
}
