using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Interfaces;

namespace Almacenamiento
{
    public class SerializadorJson<T>  where T : new()
    {
        public SerializadorJson()
        {
            
        }
        /// <summary>
        /// Carga un listado de objeto desde un archivo json
        /// </summary>
        /// <param name="ruta">Ruta del archivo</param>
        /// <param name="nombreArchivo">Nombre del archivo</param>
        /// <returns></returns>
        public List<T> Cargar(string ruta, string nombreArchivo)
        {
            string rutaCompleta = GetRutaCompleta(ruta,nombreArchivo);
            using (StreamReader sr = new StreamReader(rutaCompleta))
            {
                string json="";
                while (!sr.EndOfStream)
                {
                    json += sr.ReadLine();
                }
                T[] elementos = JsonSerializer.Deserialize<T[]>(json);
                return elementos.ToList();
            }
        }
        /// <summary>
        /// Guarda una lista en un archivo serializado en json
        /// </summary>
        /// <param name="coleccion">Lista a guardar</param>
        /// <param name="ruta">Directorio en el cual guardar el archivo</param>
        /// <param name="nombre">Nombre del archivo</param>
        public void Guardar(List<T> coleccion, string ruta, string nombreArchivo)
        {
            string rutaCompleta = ruta + @"\" + nombreArchivo;
            string json = JsonSerializer.Serialize(coleccion.ToArray());
            File.WriteAllText(rutaCompleta, json);
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
