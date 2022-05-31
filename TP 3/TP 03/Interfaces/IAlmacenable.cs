using System;
using System.Collections.Generic;
namespace Interfaces
{
    public interface IAlmacenable<T> where T : new()
    {
        public int Guardar(ICollection<T> coleccion, string ruta, string nombre);
        public List<T> Cargar(string ruta,string nombreArchivo);

    }
}
