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
    public class SerializadorJson<T> : IAlmacenar<T> where T : new()
    {
        public SerializadorJson()
        {
            
        }

        public List<T> Cargar(string ruta, string nombreArchivo)
        {
            string rutaCompleta = ruta + @"\" + nombreArchivo;
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

        public void Guardar(List<T> coleccion, string ruta, string nombreArchivo)
        {
            string rutaCompleta = ruta + @"\" + nombreArchivo;
            string json = JsonSerializer.Serialize(coleccion.ToArray());
            File.WriteAllText(rutaCompleta, json);
        }
    }
}
