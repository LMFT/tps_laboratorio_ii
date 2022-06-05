using System;
using System.IO;
namespace Almacenamiento
{
    /// <summary>
    /// Genera archivos de uso interno de la aplicacion
    /// </summary>
    public static class ArchivadorInterno
    {

        public static bool ArchivoExiste(string nombre)
        {
            nombre = nombre.Trim();
            string rutaCompleta = Path.GetFullPath(nombre);
            return File.Exists(rutaCompleta);
        }

        public static string Leer(string nombre)
        {
            string texto = string.Empty;
            nombre = nombre.Trim();
            string rutaCompleta =Path.GetFullPath(nombre);
            try
            {
                using(StreamReader sr = new StreamReader(rutaCompleta))
                {
                    texto = sr.ReadLine();
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
                    //Por razones que no terminé de entender, al realizar la lectura desde un archivo
                    //a veces la lectura incluye un \r\n, lo cual modifica el texto ingresado.
                    //Como solucion temporal estoy verificando y removiendo manualmente esta terminacion
                    //if (texto.EndsWith(@"\r\n"))
                    //{
                    //    texto = texto.Remove(texto.Length - 4);
                    //}
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
