using System;
using System.Collections.Generic;

namespace Entidades
{
    public static class Clinica
    {
        private static List<Usuario> usuarios;
        private static List<Medico> medicos;
        private static List<Paciente> pacientes;
        private static List<Consulta> consultas;
        static Clinica()
        {
            HardcodearPersonal();
        }

        private static void HardcodearPersonal()
        {
            HardcodearUsuarios();
        }

        private static void HardcodearUsuarios()
        {
            string[] nombres = { "Fernanda", "Damian", "Rodrigo", "Romina"};
            string[] apellidos = { "Casals", "Vietti", "Caranza", "Fernandez"};
            int[] documentos = { 2234567, 34332211, 25312332, 31323234 };

            usuarios = new List<Usuario>();

            for(int i = 0; i < nombres.Length; i++)
            {
                usuarios.Add(new Usuario(nombres[i], apellidos[i], documentos[i], (Permisos)(i%3)));
            }
        }

        public static Usuario BuscarUsuario(string nombreUsuario)
        {
            foreach(Usuario usuario in usuarios)
            {
                if(usuario.NombreUsuario == nombreUsuario)
                {
                    return usuario;
                }
            }
            return null;
        }

        public static Usuario BuscarUsuario(int id)
        {
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Id == id)
                {
                    return usuario;
                }
            }
            return null;
        }

        public static Usuario BuscarUsuario(bool esAdministrador)
        {
            foreach (Usuario usuario in usuarios)
            {
                if (esAdministrador && usuario.Permisos == Permisos.Administrador ||
                                       usuario.Permisos == Permisos.Duenio)
                {
                    return usuario;
                }
                else
                {
                    if(!esAdministrador && usuario.Permisos == Permisos.Empleado)
                    {
                        return usuario;
                    }
                }
            }
            return null;
        }
    }
}
