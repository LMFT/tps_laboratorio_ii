using Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class UsuarioInterno : Persona,IObtener<Usuario>
    {
        private string nombreUsuario;
        private string password;
        private Permisos permisos;

        public UsuarioInterno()
        {
            nombre = string.Empty;
            apellido = string.Empty;
            dni = 0;
            nombreUsuario = string.Empty;
            password = string.Empty;
            permisos = Permisos.Empleado;
        }

        public UsuarioInterno(Usuario usuario)
        {
            nombre = usuario.Nombre;
            apellido = usuario.Apellido;
            dni = usuario.Dni;
            nombreUsuario = usuario.NombreUsuario;
            password = "";
            foreach(int numero in usuario.CodificarPassword(out int clave))
            {
                password += (char)(numero - clave / 2);
            }
            permisos = usuario.Permisos;
        }

        public new string Nombre { get => nombre; set => nombre = value; }
        public new string Apellido { get => apellido; set => apellido = value; }
        public new int Dni { get => dni; set => dni = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Password { get => password; set => password = value; }
        public Permisos Permisos { get => permisos; set => permisos = value; }

        public Usuario Obtener()
        {
            return new Usuario(this);
        }
    }
}
