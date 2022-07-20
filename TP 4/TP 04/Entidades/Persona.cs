using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Usuario))]
    public abstract class Persona
    {
        protected string nombre;
        protected string apellido;
        protected int dni;

        public Persona()
        {
            nombre = string.Empty;
            apellido = string.Empty;
            dni = -1;
        }

        public Persona(string nombre) : this()
        {
            this.nombre = nombre;
        }

        public Persona(string nombre, string apellido) : this(nombre) 
        {
            this.apellido = apellido;
        }

        public Persona(string nombre, string apellido, int dni) : this(nombre, apellido)
        {
            this.dni = dni;
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    nombre = value;
                }
            }
        }
        public string Apellido
        {
            get
            {
                return apellido;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    apellido = value;
                }
            }
        }

        public string NombreCompleto
        {
            get
            {
                return $"{nombre} {apellido}";
            }
        }

        public int Dni
        {
            get
            {
                return dni;
            }
        }

        public virtual string Mostrar()
        {
            StringBuilder personaStr = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                personaStr.AppendLine($"Nombre: {Nombre}");
            }
            if (!string.IsNullOrWhiteSpace(apellido))
            {
                personaStr.AppendLine($"Apellido: {Apellido}");
            }
            return personaStr.ToString();
        }

        internal virtual string ActualizarValores()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE = {nombre},");
            sb.AppendLine($"APELLIDO = {apellido},");
            sb.AppendLine($"DNI = {dni},");
            return sb.ToString();
        }

        internal virtual string GetValores()
        {
            return $"{nombre},{apellido},{dni}";
        }
    }
}
