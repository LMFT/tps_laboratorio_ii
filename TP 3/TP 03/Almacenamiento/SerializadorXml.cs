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
    public class SerializadorXml<T> : IAlmacenar<T>  where T : new()
    {
        public SerializadorXml()
        {

        }


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
