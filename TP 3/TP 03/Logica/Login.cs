using System;
using System.Collections.Generic;
using System.Text;

using Entidades;

namespace Logica.Login
{
    public static class Login
    {

        private static Usuario usuarioLogeado;

        internal static Usuario UsuarioLogeado
        {
            get
            {
                return usuarioLogeado;
            }
        }
        /// <summary>
        /// Valida que el nombre de usuario recibido exista, y que la contraseña sea la asociada al usuario
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario a verificar</param>
        /// <param name="password">Contraseña del usuario</param>
        /// <returns>Retorna true si el usuario existe y la contraseña recibida coincide con la registrada en el sistema.
        /// Caso contrario retorna falso</returns>
        public static bool ValidarIngreso(string nombreUsuario, string password)
        {
            Usuario usuario = Clinica.BuscarUsuario(nombreUsuario);
            if(usuario is not null && usuario.ValidarPassword(password))
            {
                usuarioLogeado = usuario;
                return true;
            }
            return false;
        }


        /// <summary>
        /// Carga automaticamente la informacion del usuario en los campos de salida. Permite distinguir entre autocompletar
        /// los campos usando una cuenta de empleado o de administraodr
        /// </summary>
        /// <param name="esAdministrador">Detemina si se deberia obtener un usuario que sea administrado</param>
        /// <param name="nombreUsuario">Nombre de usuario aucotompletado</param>
        /// <param name="password">Password aucotompletada</param>
        public static void CargarInformacion(bool esAdministrador, out string nombreUsuario, out string password)
        {
            Usuario usuario;
            nombreUsuario = String.Empty;
            password = String.Empty;
            
            usuario = Clinica.BuscarUsuario(esAdministrador); 
            
            if(usuario is not null)
            {
                nombreUsuario = usuario.NombreUsuario;
                password = GetPassword(usuario);
            }
        }
        /// <summary>
        /// Obtiene la contraseña codificada del usuario, la decodifica y la retorna para el campo autocompletado
        /// </summary>
        /// <param name="usuario">Usuario del cual queremos obtener la contraseña</param>
        /// <returns></returns>
        private static string GetPassword(Usuario usuario)
        {
            List<int> passwordCodificada = usuario.CodificarPassword(out int clave);
            StringBuilder password = new StringBuilder();
            foreach (int numero in passwordCodificada)
            {
                password.Append((char)(numero - clave / 2));
            }
            return password.ToString();
        }
    }
}
