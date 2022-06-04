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
    public class SerializadorXml<T> : IAlmacenable<T> where T : new()
    {
        private string ruta;

        public SerializadorXml()
        {
            this.ruta = AppDomain.CurrentDomain.BaseDirectory;
        }
        public SerializadorXml(string ruta)
        {
            this.ruta = ruta;
        }

        public List<T> Cargar(string ruta, string nombreArchivo)
        {
            List<T> lista = new List<T>();
            string rutaCompleta = ruta + @"\" + nombreArchivo;
            using(StreamReader sr = new StreamReader(rutaCompleta))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                T elemento = (T)xmlSerializer.Deserialize(sr);
                if(elemento is not null)
                {
                    lista.Add(elemento);
                }
            }
            return lista;
        }

        public List<T>Cargar(string nombre)
        {
            return Cargar(ruta, nombre);
        }

        public int Guardar(List<T> coleccion, string ruta, string nombre)
        {
            int i = 0;
            string rutaCompleta = GetRutaCompleta(ruta,nombre);

            if (string.IsNullOrEmpty(rutaCompleta))
            {
                using (StreamWriter sw = new StreamWriter(rutaCompleta))
                {
                    foreach (T elemento in coleccion)
                    {
                        XmlSerializer xml = new XmlSerializer(typeof(T));
                        xml.Serialize(sw, elemento);
                    }
                }
            }
            return i;
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
