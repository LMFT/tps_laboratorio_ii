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
            try
            {
                switch (mostrarInfo)
                {
                    //En el caso de un usuario, el primer campo representa nombre, segundo apellido, tercero DNI, cuato usuario,
                    //quinto pass. El booleano representa el nivel de permisos
                    case MostrarInfo.Empleado:
                        return NuevoEmpleado(primerCampo, segundoCampo, tercerCampo, opcionCheckbox, cuartoCampo, quintoCampo);
                    //Para los productos evaluo que radioButton estaba seleccionado al ingresar al método. Segun el resultado,
                    //cambia el objeto a instanciar
                    case MostrarInfo.Producto:
                        if (rdoCable)
                        {
                            
                            return NuevoProducto(primerCampo, segundoCampo, tercerCampo, cuartoCampo, opcionCheckbox, cantidad);
                        }
                        return NuevoProducto(primerCampo,segundoCampo,tercerCampo,cuartoCampo,quintoCampo,cantidad);
                    //Por defecto, si no es un producto o empleado, es un proveedor
                    default:
                        return NuevoProveedor(primerCampo,segundoCampo,tercerCampo);
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        private static bool NuevoEmpleado(string nombre, string apellido, string dni, bool administrador,
                                          string nombreUsuario, string password)
        {
            Permisos permisos = Permisos.Empleado;
            if (int.TryParse(dni, out int dniInt))
            {
                if(string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
                {
                    throw new NullReferenceException("Verifique que tanto el nombre como el apellido " +
                        "contengan caracteres");
                }
                if (administrador)
                {
                    permisos = Permisos.Administrador;
                }
                Usuario usuario = InstanciarUsuario(nombre,apellido,dniInt,permisos,nombreUsuario,password);
                
                return CasaElectronica.AltaEmpleado(usuario);
            }
            throw new ArgumentException("Verifique que el valor del campo DNI" +
                " sea numérico");
        }

        private static Usuario InstanciarUsuario(string nombre, string apellido, int dni, Permisos permisos,
                                          string nombreUsuario, string password)
        {
            Usuario usuario;
            switch (string.IsNullOrWhiteSpace(password))
            {
                case false:
                    usuario = new Usuario(nombre, apellido, dni, permisos, nombreUsuario, password);
                    break;
                case true:
                    if (string.IsNullOrWhiteSpace(nombreUsuario))
                    {
                        usuario = new Usuario(nombre, apellido, dni, permisos);
                        break;
                    }
                    usuario = new Usuario(nombre, apellido, dni, permisos, nombreUsuario);
                    break;
            }
            return usuario;
        }

        private static bool NuevoProducto(string nombre, string precio, string marca, string seccion,bool dobleAislacion,
                                          int cantidad)
        {
            if(decimal.TryParse(precio, out decimal precioDecimal) && double.TryParse(seccion, out double seccionDouble))
            {
                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(marca))
                {
                    throw new NullReferenceException("La informacion ingresada no es válida. Verifique que el nombre y la" +
                        " marca del cable contengan caracteres");
                }
                Producto producto = new Cable(nombre, precioDecimal, marca, seccionDouble, dobleAislacion);
                return CasaElectronica.AltaProducto(producto, cantidad);
            }
            throw new ArgumentException("La informacion ingresada no es válida. Verifique que el valor de los campos " +
                "precio y seccion sean numéricos");
                
        }

        private static bool NuevoProducto(string nombre, string precio, string marca, string capacidad, 
                                          string unidadMedicion, int cantidad)
        {
            if (decimal.TryParse(precio, out decimal precioDecimal) && 
                double.TryParse(capacidad, out double capacidadDouble))
            {
                if(string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(marca)  ||
                   string.IsNullOrWhiteSpace(unidadMedicion))
                {
                    throw new NullReferenceException("La informacion ingresada no es válida. Verifique que el nombre, marca" +
                        "y la unidad de medicion del componente contengan caracteres");
                }
                Producto producto = new Componente(nombre, precioDecimal, marca, capacidadDouble, unidadMedicion);
                return CasaElectronica.AltaProducto(producto, cantidad);
            }
            throw new ArgumentException("La informacion ingresada no es válida. Verifique que el valor de los campos pre" +
                "cio y capacidad sean numéricos");
        }
        /// <summary>
        /// Da de alta un nuevo proveedor
        /// </summary>
        /// <param name="nombre">Nombre del proveedor</param>
        /// <param name="apellido">Apellido del proveedor</param>
        /// <param name="dniStr">Dni del proveedor</param>
        /// <returns>Retorna true si pudo dar de alta al proveedor, de lo contrario false</returns>
        /// <exception cref="ArgumentException">Si alguno de los parametros no es válido para crear un proveedor
        /// lanza esta extepcion</exception>
        private static bool NuevoProveedor(string nombre, string apellido, string dniStr)
        {
            if(int.TryParse(dniStr, out int dni))
            {
                if(!string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(apellido))
                {
                    Proveedor proveedor = new Proveedor(nombre,apellido,dni, productosDisponibles);
                    return CasaElectronica.AltaProveedor(proveedor);
                }
            }
            throw new ArgumentException("La informacion ingresada no es válida. Verifique que los campos nombre y" +
                "apellido contengan caracteres ademas del espacio, y que el campo DNI sea numérico");
        }

        /// <summary>
        /// Valida que el nombre de usuario ingresado no esté ya registrado
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario a validar</param>
        /// <returns>Retorna true si ningun usuario ocupa el nombre de usuario. Caso
        /// contrario retorna false</returns>
        /// <exception cref="ArgumentException">En caso de recibir un null, texto vacio o con solo espacios en blanco
        /// lanza una nueva ArgumentException</exception>
        public static bool ValidarUsuario(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                throw new ArgumentException("El nombre de usuario está vacío, " +
                                            " ingrese un nombre de usuario e intente nuevamente");
            }
            foreach(Usuario usuario in CasaElectronica.Personal)
            {
                if(usuario.NombreUsuario == nombreUsuario)
                {
                    return false;
                }
            }
            return true;
        }


        public static void AgregarProductos()
        {
            productosDisponibles = ControladorAgregar.Productos;
        }
    }
}
