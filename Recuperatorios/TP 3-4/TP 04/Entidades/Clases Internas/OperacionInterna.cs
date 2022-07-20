using Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class OperacionInterna : IObtener<Operacion>
    {
        private List<Producto> productos;
        private decimal total;
        private int id;

        public OperacionInterna()
        {
            id = 0;
            total = 0;
            productos = new List<Producto>();
        }

        public OperacionInterna(Operacion operacion)
        {
            id = operacion.Id;
            total = operacion.Total;
            productos = operacion.Productos;
        }

        public List<Producto> Productos { get => productos; set => productos = value; }
        public decimal Total { get => total; set => total = value; }
        public int Id { get => id; set => id = value; }

        public Operacion Obtener()
        {
            return new Operacion(id,total,productos);
        }
    }
}
