using Interfaces;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Almacenamiento
{
    public class SerializadorXml<T> where T : new()
    {
        public SerializadorXml()
        {

        }

        /// <summary>
        /// Carga un listado de objeto desde un archivo xml
        /// </summary>
        /// <param name="ruta">Ruta del archivo</param>
        /// <param name="nombreArchivo">Nombre del archivo</param>
        /// <returns></returns>
        public List<T> Cargar(string ruta, string nombreArchivo)
        {
            string rutaCompleta = ruta + @"\" + nombreArchivo;
            using(StreamReader sr = new StreamReader(rutaCompleta))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]));
                T[] elementos = (T[])xmlSerializer.Deserialize(sr);
                if(elementos is not null)
                {
                    return elementos.ToList();
                }
            }
            return null;
        }
        /// <summary>
        /// Guarda una lista en un archivo serializado en xml
        /// </summary>
        /// <param name="coleccion">Lista a guardar</param>
        /// <param name="ruta">Directorio en el cual guardar el archivo</param>
        /// <param name="nombre">Nombre del archivo</param>
        public void Guardar(List<T> coleccion, string ruta, string nombre)
        {
            string rutaCompleta = GetRutaCompleta(ruta,nombre);

            if (!string.IsNullOrEmpty(rutaCompleta))
            {
                using (StreamWriter sw = new StreamWriter(rutaCompleta))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(T[]));
                    xml.Serialize(sw, coleccion.ToArray());
                }
            }
        }
        /// <summary>
        /// Retorna una unica ruta hacia un archivo, a partir de una ruta a un directorio y el nombre de un archivo
        /// </summary>
        /// <param name="ruta">Directorio del archivo</param>
        /// <param name="nombre">Nombre del archivo</param>
        /// <returns>Retorna una cadena con la ruta absoluta hacia un archivo</returns>
        private string GetRutaCompleta(string ruta, string nombre)
        {
            ruta = ruta.Trim();
            nombre = nombre.Trim();
            if (ruta.EndsWith(@"\"))
            {
                return ruta + nombre;
            }
            return ruta + @"\" + nombre;
        }
    }
}
