using System;
using System.Collections.Generic;
namespace Interfaces
{
    public interface IAlmacenar<T> where T : new()
    {
        public void Guardar(List<T> coleccion, string ruta, string nombre);
        public List<T> Cargar(string ruta,string nombreArchivo);

    }
}
