using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TareaInterna
    {
        private int ultimoId;
        private int id;
        private string descripcion;
        private DateTime fechaHoraCreacion;

        public TareaInterna()
        {
            ultimoId = 0;
            id = 0;
            descripcion = "";
            fechaHoraCreacion = DateTime.MinValue;
        }

        public TareaInterna(Tarea tarea)
        {
            ultimoId = tarea.UltimoId;
            id = tarea.Id;
            descripcion = tarea.Descripcion;
            fechaHoraCreacion = tarea.FechaHora;
        }

        public int UltimoId { get => ultimoId; set => ultimoId = value; }
        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime FechaHora { get => fechaHoraCreacion; set => fechaHoraCreacion = value; }
    }
}
