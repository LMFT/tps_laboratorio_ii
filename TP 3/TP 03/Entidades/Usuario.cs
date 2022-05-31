using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum Permisos
    {
        Empleado,
        Administrador,
        Duenio,
    }
    public class Usuario : Persona
    {
        private string nombreUsuario;
        private string password;
        private Permisos permisos;


        public Usuario(string nombre, string apellido, int dni, Permisos permisos)
        : base(nombre, apellido, dni)
        {
            nombreUsuario = GenerarNombreUsuario(nombre, apellido);
            password = "1234";
            this.permisos = permisos;
        }

        public Usuario(string nombre, string apellido, int dni, Permisos nivelAcceso, string nombreUsuario) 
        : this(nombre, apellido,dni,nivelAcceso)
        {
            if (!string.IsNullOrEmpty(nombreUsuario))
            {
                this.nombreUsuario = nombreUsuario;
            }
        }

        public Usuario(string nombre, string apellido, int dni, Permisos nivelAcceso, string nombreUsuario, string password)
        : this(nombre, apellido, dni, nivelAcceso, nombreUsuario)
        {
            if (!string.IsNullOrEmpty(nombreUsuario))
            {
                this.password = password;
            }
        }

        public int Dni
        {
            get
            {
                return dni;
            }
        }

        public string NombreUsuario
        {
            get 
            { 
                return nombreUsuario; 
            }
        }

        public Permisos Permisos
        {
            get
            {
                return permisos;
            }
        }

        public static bool operator == (List<Usuario> lu, Usuario u)
        {
            if(u is not null && lu is not null)
            {
                foreach(Usuario u1 in lu)
                {
                    if(u1 == u)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator !=(List<Usuario> lu, Usuario u)
        {
            return !(lu == u);
        }

        public static List<Usuario> operator +(List<Usuario> lu, Usuario u )
        {
            if (u is not null && lu is not null)
            {
                lu.Add(u);
            }
            return lu;
        }

        public static bool operator -(List<Usuario> lu, Usuario u) 
        {
            if(u is not null && lu is not null)
            {
                return lu.Remove(u);
            }
            return false;
        }

        public bool ValidarPassword(string password)
        {
            return this.password == password;
        }
        /// <summary>
        /// Retorna la contraseña codificada en forma de lista de enteros
        /// </summary>
        /// <param name="n"></param>
        /// <returns>Contraseña codificada en forma de enteros</returns>
        public List<int> CodificarPassword(out int clave)
        {
            /*Para codificar la clave la idea es modificar el valor ascii de cada caracter por 
             * un valor generado aleatoriamente dentro de la funcion. No es ciertamente el sistema
             mas complejo pero es para tener algo temporal que utilizar para obtener la contraseña 
            sin comprometer la misma*/
            Random rng = new Random(DateTime.Now.GetHashCode());
            
            //Para que esta codificacion tenga sentido la clave no puede ser 0
            do
            {
                clave = rng.Next(-200, 200);
            } while (clave == 0);

            List<int> passCodificada = new List<int>();
            //Cada caracter de la contraseña será alterado sumando el valor de la clave, dividido 2
            foreach(char c in password)
            {
                passCodificada.Add(c + clave/2);
            }
            return passCodificada;
        }
        /// <summary>
        /// Genera un nombre de usuario utilizando la inicial de un nombre y un apellido
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <returns>Nombre de usuario generado automaticamente</returns>
        public static string GenerarNombreUsuario(string nombre, string apellido)
        {
            return nombre.ToLower()[0] + apellido.ToLower();
        }
        /// <summary>
        /// Busca un usuario en una lista en base a su nombre de usuario
        /// </summary>
        /// <param name="lista">Lista de usuarios</param>
        /// <param name="nombreUsuario">Nombre de usuario a buscar</param>
        /// <returns>Usuario cuyo nombre de usuario coincide con el recibido por parametro,
        /// de no encontrar una coincidencia retorna null</returns>
        public static Usuario BuscarPorNombreDeUsuario(List<Usuario> lista,string nombreUsuario)
        {
            foreach (Usuario usuario in lista)
            {
                if (usuario.NombreUsuario == nombreUsuario)
                {
                    return usuario;
                }
            }
            return null;
        }
        /// <summary>
        /// Busca un usuario por su id
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Usuario BuscarPorId(List<Usuario> lista, int id)
        {
            foreach (Usuario usuario in lista)
            {
                if (usuario.Dni == id)
                {
                    return usuario;
                }
            }
            return null;
        }
        /// <summary>
        /// Obtiene la primer coincidencia en una lista, basandose en si requiere un usuario
        /// que sea administrador o empleado
        /// </summary>
        /// <param name="lista">Lista de usuarios</param>
        /// <param name="admin">Indica si el usuario retornado debe ser administrador</param>
        /// <returns>Primer usuario que coincida con el criterio de búsqueda, o null si ninguno
        /// cumple con el criterio</returns>
        public static Usuario Obtener(List<Usuario> lista, bool admin)
        {
            if(lista is not null && lista.Count > 0)
            {
                foreach (Usuario usuario in lista)
                {
                    if ((admin && (usuario.Permisos == Permisos.Administrador || usuario.Permisos == Permisos.Duenio)) ||
                       !admin && usuario.Permisos == Permisos.Empleado)
                    {
                        return usuario;
                    }
                }
            }
            return null;
        }

        public override int GetHashCode()
        {
            return dni.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Usuario usuario && this == usuario;
        }
    }
}
