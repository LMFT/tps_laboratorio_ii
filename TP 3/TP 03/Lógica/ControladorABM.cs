using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

using Logica.AgregarPedidos;
using Logica.MenuPrincipal;

using Mostrar;
namespace Logica.ABM
{
    public static class ControladorABM
    {
        public static bool UsuarioEsAdmin
        {
            get
            {
                return ControladorMenuPrincipal.UsuarioEsAdmin;
            }
        }
        /// <summary>
        /// Instancia un nuevo elemento del tipo solicitado
        /// </summary>
        /// <param name="mostrarInfo">Determina el tipo de objeto a instanciar</param>
        /// <param name="camposAdiconales">Indica si se utilizaron los campos adicionales
        /// en la interfaz para incluir sus datos en el nuevo objeto</param>
        /// <param name="opcionCheckbox">Determina si la opcion booleana de la interfaz se 
        /// encuentra activa, permitiendo añadir su valor al objeto</param>
        /// <param name="primerCampo">Contenido del primer textbox</param>
        /// <param name="segundoCampo">Contenido del segundo textbox</param>
        /// <param name="tercerCampo">Contenido del tercer textbox</param>
        /// <param name="cuartoCampo">Contenido del cuarto textbox</param>
        /// <param name="quintoCampo">Contenido del quinto textbox</param>
        /// <returns>Retorna la instancia del objeto creado. Si el tipo de dato a crear no coincide
        /// con ningun valor dado retorna null</returns>
        private static object CrearElemento(MostrarInfo mostrarInfo, bool camposAdiconales, bool opcionCheckbox,string primerCampo,
                                                string segundoCampo, string tercerCampo, string cuartoCampo, string quintoCampo)
        {
            switch (mostrarInfo)
            {
                //En el caso de un usuario, el primer campo representa nombre, segundo apellido, tercero DNI, cuato usuario,
                //quinto pass. El booleano representa el nivel de permisos
                case MostrarInfo.Empleado:
                    Permisos permisos = Permisos.Empleado;
                    if (int.TryParse(tercerCampo, out int dni))
                    {
                        if (opcionCheckbox)
                        {
                            permisos = Permisos.Administrador;
                        }
                        //La opcion de campos adicionales permite crear un usuario y contraseña personalizados
                        //Por defecto el usuario es la inicial del nombre + el apellido, en minusculas. 
                        //ej. Carla Fernandez tendria el usuario cfernandez. En caso de existir se suma un numero al final del
                        //usuario (cfernandez1, cfernandez2, etc.)
                        //La contraseña por defecto es "1234"
                        if (camposAdiconales)
                        {
                            return new Usuario(primerCampo, segundoCampo, dni, permisos, cuartoCampo, quintoCampo);
                        }
                        return new Usuario(primerCampo, segundoCampo, dni, permisos, GenerarUsuario(primerCampo,segundoCampo));
                    }
                    break;
                case MostrarInfo.Producto:
                    if(decimal.TryParse(segundoCampo, out decimal precio) &&
                       double.TryParse(cuartoCampo, out double seccion))
                    {
                        //De incluirse campos adicionales, se permite añadir ingredientes necesarios para preparar los consumibles,
                        //permitiendo tanto seleccionar de los ya existentes como dar de alta nuevos
                        if (camposAdiconales)
                        {
                            return new Cable(primerCampo, precio,tercerCampo,seccion,opcionCheckbox);
                        }
                    }
                    break;
                default:
                    if(decimal.TryParse(segundoCampo, out decimal precioComponente)&&
                        double.TryParse(cuartoCampo, out double capacidad))
                    {
                        return new Componente(primerCampo, precioComponente,tercerCampo, capacidad,quintoCampo);
                    }
                    break;
            }
            return null;
        }
        /// <summary>
        /// Instancia un nuevo objeto de un tipo determinado y lo añade a su correspondiente coleccion
        /// </summary>
        /// <param name="mostrarInfo">Determina el tipo de objeto a instanciar</param>
        /// <param name="camposAdiconales">Indica si se utilizaron los campos adicionales
        /// en la interfaz para incluir sus datos en el nuevo objeto</param>
        /// <param name="opcionCheckbox">Determina si la opcion booleana de la interfaz se 
        /// encuentra activa, permitiendo añadir su valor al objeto</param>
        /// <param name="primerCampo">Contenido del primer textbox</param>
        /// <param name="segundoCampo">Contenido del segundo textbox</param>
        /// <param name="tercerCampo">Contenido del tercer textbox</param>
        /// <param name="cuartoCampo">Contenido del cuarto textbox</param>
        /// <param name="quintoCampo">Contenido del quinto textbox</param>
        /// <returns>Retorna true si pudo instanciarse y añadirse el objeto a su coleccion.
        /// Caso contrario retorna false</returns>
        public static bool CargarElemento(MostrarInfo mostrarInfo, bool camposAdicionales, bool opcionCheckbox, string primerCampo, 
            string segundoCampo, string tercerCampo, string cuartoCampo, string quintoCampo)
        {
            var item = CrearElemento(mostrarInfo, camposAdicionales,opcionCheckbox, primerCampo, segundoCampo, tercerCampo, 
                                     cuartoCampo, quintoCampo);
            if(item is not null)
            {
                if(item is Usuario usuario)
                {
                    return CasaElectronica.AltaEmpleado(usuario);
                }
                else
                {
                    
                }
            }
            return false;
        }
        /// <summary>
        /// Valida que el nombre de usuario ingresado no esté ya registrado
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario a validar</param>
        /// <returns>Retorna true si ningun usuario ocupa el nombre de usuario. Caso
        /// contrario retorna false</returns>
        public static bool ValidarUsuario(string nombreUsuario)
        {
            foreach(Usuario usuario in CasaElectronica.Personal)
            {
                if(usuario.NombreUsuario == nombreUsuario)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Genera un nombre de usuario por defecto y valida que no exista
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <returns>Nombre de usuario generado automáticamente, garantizando que no se repite</returns>
        public static string GenerarUsuario(string nombre, string apellido)
        {
            string nombreUsuario = Usuario.GenerarNombreUsuario(nombre, apellido);
            int i = 0;
            while (!ValidarUsuario(nombreUsuario))
            {
                i++;
                nombreUsuario = Usuario.GenerarNombreUsuario(nombre, apellido) + i.ToString();
            }
            return nombreUsuario;
        }
    }
}
