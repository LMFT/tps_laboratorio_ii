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
        private DateTime fechaHoraCreacion;

        static Tarea()
        {
            ultimoId = 0;
        }
        public Tarea(string descripcion)
        {
            id = ++ultimoId;
            this.descripcion = descripcion;
            fechaHoraCreacion = DateTime.Now;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Fecha: {fechaHoraCreacion.Date}");
            sb.AppendLine($"Hora: {fechaHoraCreacion.TimeOfDay}");
            sb.AppendLine($"Descripcion: {descripcion}");
            return sb.ToString();
        }
    }
}
