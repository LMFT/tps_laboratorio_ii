using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tarea
    {
        private static int ultimoId;
        private int id;
        private string descripcion;
        private DateTime fechaHora;

        static Tarea()
        {
            ultimoId = 0;
        }

        internal Tarea(TareaInterna tarea)
        {
            Tarea.ultimoId = tarea.UltimoId;
            id = tarea.Id;
            descripcion = tarea.Descripcion;
            fechaHora = tarea.FechaHora;
        }

        public Tarea(string descripcion)
        {
            id = ++ultimoId;
            this.descripcion = descripcion;
            fechaHora = DateTime.Now;
        }

        public int Id
        {
            get
            {
                return id;
            }
        }
        public int UltimoId
        {
            get
            {
                return ultimoId;
            }
        }
        public string Descripcion
        {
            get
            {
                return descripcion;
            }
        }
        public DateTime FechaHora
        {
            get
            {
                return fechaHora;
            }
        }

        internal void SetDescripcion(string descripcion)
        {
            if (!string.IsNullOrWhiteSpace(descripcion))
            {
                this.descripcion = descripcion;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Fecha: {fechaHora.Date}");
            sb.AppendLine($"Hora: {fechaHora.TimeOfDay}");
            sb.AppendLine($"Descripcion: {descripcion}");
            return sb.ToString();
        }
    }
}
