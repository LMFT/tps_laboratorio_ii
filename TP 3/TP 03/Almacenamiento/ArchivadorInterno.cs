using System;
using System.IO;
namespace Almacenamiento
{
    /// <summary>
    /// Genera archivos de uso interno de la aplicacion
    /// </summary>
    public static class ArchivadorInterno
    {
        /// <summary>
        /// Verifica que un archivo exista en las carpetas internas de la aplicacion
        /// </summary>
        /// <param name="nombre">Nombre del archivo</param>
        /// <returns>True si el arrchivo existe, de lo contrario false</returns>
        public static bool ArchivoExiste(string nombre)
        {
            nombre = nombre.Trim();
            string rutaCompleta = Path.GetFullPath(nombre);
            return File.Exists(rutaCompleta);
        }
        /// <summary>
        /// Lee un archivo que se encuentra dentro de la carpeta de la aplicacion
        /// </summary>
        /// <param name="nombre">Nombre del archivo</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string Leer(string nombre)
        {
            string texto = string.Empty;
            nombre = nombre.Trim();
            string rutaCompleta =Path.GetFullPath(nombre);
            try
            {
                if (ArchivoExiste(nombre))
                {
                    using(StreamReader sr = new StreamReader(rutaCompleta))
                    {
                        texto = sr.ReadLine();
                    }
                }
                return texto;
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrio un error inesperado", ex);
            }
        }
        /// <summary>
        /// Escribe un nuevo archivo dentro de la carpeta de la aplicacion
        /// </summary>
        /// <param name="nombre">Nombre del archivo</param>
        /// <param name="texto">Texto a escribir</param>
        /// <exception cref="Exception"></exception>
        public static void Escribir(string nombre, string texto)
        {
            string rutaCompleta = Path.GetFullPath(nombre);
            try
            {
                if (!ArchivoExiste(rutaCompleta))
                {
                    FileStream archivo = File.Create(rutaCompleta);
                    archivo.Close();
                }
                using(StreamWriter sw = new StreamWriter(rutaCompleta))
                {
                    sw.WriteLine(texto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error inesperado", ex);
            }
        }
    }
}
