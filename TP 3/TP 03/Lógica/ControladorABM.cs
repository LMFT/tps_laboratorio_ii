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
        private static List<Producto> productosDisponibles;
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
        public static bool CrearElemento(MostrarInfo mostrarInfo, bool opcionCheckbox,string primerCampo,
                                          string segundoCampo, string tercerCampo, string cuartoCampo, 
                                          string quintoCampo, bool rdoCable, int cantidad)
        {
            switch (mostrarInfo)
            {
                //En el caso de un usuario, el primer campo representa nombre, segundo apellido, tercero DNI, cuato usuario,
                //quinto pass. El booleano representa el nivel de permisos
                case MostrarInfo.Empleado:
                    return NuevoEmpleado(primerCampo, segundoCampo, tercerCampo, opcionCheckbox, cuartoCampo, quintoCampo);
                case MostrarInfo.Producto:
                    if (rdoCable)
                    {
                        return NuevoProducto(primerCampo, segundoCampo, tercerCampo, cuartoCampo, opcionCheckbox, cantidad);
                    }
                    return NuevoProducto(primerCampo,segundoCampo,tercerCampo,cuartoCampo,quintoCampo,cantidad);
                default:
                    return NuevoProveedor(primerCampo,segundoCampo,tercerCampo);
            }
        }

        private static bool NuevoEmpleado(string nombre, string apellido, string dni, bool administrador,
                                          string nombreUsuario, string password)
        {
            Permisos permisos = Permisos.Empleado;
            if (int.TryParse(dni, out int dniInt))
            {
                if (administrador)
                {
                    permisos = Permisos.Administrador;
                }
                Usuario usuario = new Usuario(nombre, apellido, dniInt, permisos, nombreUsuario, password);
                return CasaElectronica.AltaEmpleado(usuario);
            }
            return false;
        }

        private static bool NuevoProducto(string nombre, string precio, string marca, string seccion,bool dobleAislacion,
                                          int cantidad)
        {
            if(decimal.TryParse(precio, out decimal precioDecimal) && double.TryParse(seccion, out double seccionDouble))
            {
                Producto producto = new Cable(nombre, precioDecimal, marca, seccionDouble, dobleAislacion);
                return CasaElectronica.AltaProducto(producto, cantidad);
            }
            return false;
        }

        private static bool NuevoProducto(string nombre, string precio, string marca, string capacidad, 
                                          string unidadMedicion, int cantidad)
        {
            if (decimal.TryParse(precio, out decimal precioDecimal) && 
                double.TryParse(capacidad, out double capacidadDouble))
            {
                Producto producto = new Componente(nombre, precioDecimal, marca, capacidadDouble, unidadMedicion);
                return CasaElectronica.AltaProducto(producto, cantidad);
            }
            return false;
        }

        private static bool NuevoProveedor(string nombre, string apellido, string dniStr)
        {
            if(int.TryParse(dniStr, out int dni))
            {
                Proveedor proveedor = new Proveedor(nombre,apellido,dni, productosDisponibles);
                return CasaElectronica.AltaProveedor(proveedor);
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

        public static bool EsComponente(object elemento)
        {
            return elemento is Componente;
        }

        public static void AgregarProductos()
        {
            productosDisponibles = ControladorAgregar.Productos;
        }
    }
}
