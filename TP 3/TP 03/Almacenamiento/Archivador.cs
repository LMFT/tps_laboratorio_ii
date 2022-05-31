using System;
using System.IO;
namespace Almacenamiento
{
    public static class Archivador
    {
        public static bool ArchivoExiste(string ruta, string nombre)
        {
            string rutaStr = ruta.Trim();
            string nombreStr = nombre.Trim();
            return File.Exists(rutaStr + @"\" + nombreStr);
        }

        public static bool ArchivoExiste(string nombre)
        {
            return ArchivoExiste(AppDomain.CurrentDomain.BaseDirectory + nombre);
        }

        public static string Leer(string ruta, string nombre)
        {
            string texto = string.Empty;
            string rutaStr = ruta.Trim();
            string nombreStr = nombre.Trim();
            string rutaCompleta = rutaStr+ @"\" + nombreStr;
            try
            {
                using(StreamReader sr = new StreamReader(rutaCompleta))
                {
                    texto += sr.ReadToEnd();
                }
                return texto;
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException("No se encuentra el archivo ingresado", ex);
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrio un error inesperado", ex);
            }
        }

        public static string Leer(string nombre)
        {
            return Leer(AppDomain.CurrentDomain.BaseDirectory, nombre);
        }
    }
}
