using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Almacenamiento;

namespace Entidades
{
    public enum ETipoCarga
    {
        Producto,
        Empleado,
        Proveedor
    }
    public static class CasaElectronica
    {
        private static List<Usuario> personal;
        private static Dictionary<Producto, int> stock;
        private static List<Proveedor> proveedores;
        private static List<Operacion> historial;
        private static List<Tarea> tareas;
        public static string rutaGuardado;

        public static event Action<Producto, int>  rellenarStock;

        static CasaElectronica()
        {
            historial = new List<Operacion>();
            stock = new Dictionary<Producto, int>();
            personal = new List<Usuario>();
            proveedores = new List<Proveedor>();
            tareas = new List<Tarea>();
            rutaGuardado = string.Empty;

            try
            {
                if (!GestorBaseDatos.ConexionEstablecida)
                {
                    throw new Exception("No se pudo establecer la conexion con la base de datos.");
                }
                Cargar();
            }
            catch (Exception)
            {
                HardcodearPersonal();
                HardcodearStock();
                HardcodearProveedores();
            }
        }
        /// <summary>
        /// Retorna la lista de personal del bar de forma inmutable
        /// </summary>
        public static ImmutableList<Usuario> Personal
        {
            get
            {
                return ImmutableList.Create(personal.ToArray());
            }
        }

        public static string Nombre
        {
            get
            {
                return "Electrónica Kaufmann";
            }
        }

        public static ImmutableList<Tarea> Tareas
        {
            get
            {
                return ImmutableList.Create(tareas.ToArray());
            }
        }
        /// <summary>
        /// Retorna el stock del bar de forma inmutable
        /// </summary>
        public static ImmutableDictionary<Producto, int> Stock
        {
            get
            {
                ImmutableDictionary<Producto, int> diccionario = ImmutableDictionary.Create<Producto, int>();
                diccionario = diccionario.AddRange(stock);
                return diccionario;
            }
        }

        public static ImmutableList<Proveedor> Proveedores
        {
            get
            {
                return ImmutableList.Create(proveedores.ToArray());
            }
        }

        public static Action<Producto, int> Rellenar
        {
            set
            {
                if(value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                rellenarStock+=value;
            }
        }
        /// <summary>
        /// Hardcodea el listado de personal
        /// </summary>
        private static void HardcodearPersonal()
        {
            int[] dni = { 23345678, 33445566 };
            string[] nombres = { "Agustin", "Carla" };
            string[] apellidos = { "Ramirez", "Fernandez" };
            string[] passwords = { "Contra1", "Contra2" };

            
            for (int i = 0; i < nombres.Length; i++)
            {
                Usuario usuario = new Usuario(nombres[i], apellidos[i], dni[i], (Permisos)i,
                    Usuario.GenerarNombreUsuario(nombres[i], apellidos[i]), passwords[i]);
                personal += (usuario);
            }
        }

        /// <summary>
        /// Hardcodea el stock
        /// </summary>
        private static void HardcodearStock()
        {
            string[] nombres = { "Cable", "Cable de doble aislacion", "Resistencia", "Resistencia", "Resistencia" };
            decimal[] precios = { 200M, 500M, 60M, 60M, 60M };
            string[] marcas = { "Volteck", "Backer"};
            int[] cantidades = { 2000, 1000, 75, 30, 1};
            double[] secciones = { 1.5, 6 };
            double[] capacidades = { 100,200,500};
            string unidadMedida = "ohm";

            for (int i = 0; i < nombres.Length; i++)
            {
                Producto producto;
                if (i < 2)
                {
                    producto = new Cable(nombres[i], precios[i], marcas[0], secciones[i],i%2==1);

                }
                else
                {
                    producto = new Componente(nombres[i], precios[i], marcas[1], capacidades[i-2],unidadMedida);
                }
                stock.Add(producto, cantidades[i]);
            }
        }
        /// <summary>
        /// Hardcodea los proveedores
        /// </summary>
        private static void HardcodearProveedores()
        {
            int[] dni = { 31323334, 34433211 };
            string[] nombres = { "Alberto", "Miriam" };
            string[] apellidos = { "Casals", "Ferreira" };
            List<Producto>[] productos = new List<Producto>[2];

            
            
            productos[0] = new List<Producto>();
            productos[0].Add(stock.ElementAt(0).Key);
            productos[0].Add(stock.ElementAt(1).Key);
            productos[0].Add(new Cable("Cable",150,"Volteck",2.5,false));
            productos[0].Add(new Cable("Cable Doble Aislacion", 500, "Volteck", 10, true));
            
            productos[1] = new List<Producto>();
            productos[1].Add(stock.ElementAt(2).Key);
            productos[1].Add(stock.ElementAt(3).Key);
            productos[1].Add(stock.ElementAt(4).Key);
            productos[1].Add(new Componente("Capacitor", 150, "Reggie", 50, "Micro Faradios"));

            for(int i = 0; i < dni.Length; i++)
            {
                proveedores.Add(new Proveedor(nombres[i], apellidos[i], dni[i], productos[i]));
            }
        }

        /// <summary>
        /// Busca un usuario en base al nombre de usuario registrado en la app
        /// </summary>
        /// <param name="nombreUsuario">Nombrea buscar en la lista</param>
        /// <returns>El usuario asociado al nombre de usuario, o null si no encuentra una 
        /// coincidencia</returns>
        public static Usuario BuscarUsuario(string nombreUsuario)
        {
            return Usuario.BuscarPorNombreDeUsuario(personal, nombreUsuario);
        }
        /// <summary>
        /// Busca un usuario en base a su numero de ID
        /// </summary>
        /// <param name="id">ID del usuario a buscar</param>
        /// <returns>El usuario asociado al ID recibido, o null si no encuentra una 
        /// coincidencia</returns>
        public static Usuario BuscarUsuario(int id)
        {
            return Usuario.BuscarPorId(personal, id);
        }
        /// <summary>
        /// Obtiene el primer usuario que sea empleado o administrador, en base a la condicion recibida
        /// por parametro
        /// </summary>
        /// <param name="esAdministrador">Determina si el usuario a obtener es un administrador o no</param>
        /// <returns>EL primer usuario encontrado que cumple con el criterio recibido, o null si nungun empleado 
        /// cumple con dicho criterio</returns>

        public static Usuario ObtenerUsuario(bool esAdministrador)
        {
            return Usuario.Obtener(personal, esAdministrador);
        }
        /// <summary>
        /// Valida que haya stock de un consumible, o de los ingredientes para prepararlo
        /// </summary>
        /// <param name="producto">Consumible a verificar</param>
        /// <returns>true en caso de que haya suficientes ingredientes o consumibles, de lo contrario false</returns>
        public static bool HayStock(Producto producto, int cantidad)
        {
            if(stock == producto)
            {
                return stock[producto] > cantidad;
            }
            return false;
        }
        public static bool HayStock(Producto producto)
        {
            return HayStock(producto,1);
        }

        /// <summary>
        /// Busca un producto en el stock
        /// </summary>
        /// <param name="id">ID del producto a buscar</param>
        /// <returns>Producto cuyo ID coincide con el parametro, o null si no encuentra el ID</returns>
        public static Producto BuscarProducto(int id)
        {
            return Producto.BuscarPorId(Stock.Keys.ToList(),id);
        }
        /// <summary>
        /// Permite dar de alta un usuario en nuestro sistema
        /// </summary>
        /// <param name="usuario">Usuario a dar de alta</param>
        /// <returns>true si el usuario pudo agregarse correctamente, o false si ya existe el usuario</returns>
        public static bool AltaEmpleado(Usuario usuario)
        {
            if(usuario is not null)
            {
                personal += usuario;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Añade un producto con una determinada cantidad al stock
        /// </summary>
        /// <param name="producto">Producto a añadir</param>
        /// <param name="cantidad">Cantidad de unidades del producto</param>
        /// <returns>Retorna true si pudo añadir el elemento stock</returns>
        public static bool AgregarAStock(Producto producto, int cantidad)
        {
            if (stock == producto)
            {
                return false;
            }
            stock.Add(producto, cantidad);
            return true;
        }

        /// <summary>
        /// Rellena el stock de un producto a 2 veces su cantidad mínima
        /// </summary>
        /// <param name="producto">Producto a reponer en stock</param>
        public static void ReponerStock(ElementoStock<Producto> elementoInventario)
        {
            if(elementoInventario is not null)
            {
                KeyValuePair<Producto, int> par = elementoInventario.APar();
            }
        }
        /// <summary>
        /// Repone una cantidad de unidades de un producto al stock
        /// </summary>
        /// <param name="elementoInventario">Producto a reponer</param>
        /// <param name="cantidad">Cantidad de unidades a agregar</param>
        public static void ReponerStock(ElementoStock<Producto> elementoInventario, int cantidad)
        {
            KeyValuePair<Producto, int> par = elementoInventario.APar();
            stock[par.Key] += cantidad;
        }
        /// <summary>
        /// Elimina un producto del stock
        /// </summary>
        /// <param name="producto">Producto a eliminar</param>
        /// <returns><see langword="true"/> si el producto pudo removerse, <see langword="false"/>
        /// si el producto no pudo encontrarse</returns>
        public static bool EliminarDeStock(Producto producto)
        {
            return stock - producto;
        }
        /// <summary>
        /// Elimina a un usuario del listado de personal del bar
        /// </summary>
        /// <param name="usuario">Usuario a eliminar</param>
        /// <returns>Retorna true si pudo eliminarse al usuario de la lista, de lo contrario false</returns>
        public static bool Despedir(Usuario usuario)
        {
            return personal - usuario;
        }
        
        /// <summary>
        /// Calcula el precio total de la mesa, incluyendo estacionamiento
        /// </summary>
        /// <param name="indiceMesa"></param>
        /// <returns></returns>
        public static decimal CalcularPrecioTotal(int indiceMesa)
        {
            decimal total = 0;
            
            return total;
        }

        /// <summary>
        /// Añade una nueva operacion al historial de operaciones
        /// </summary>
        /// <param name="indiceMesa">Indice de la mesa sobre la cual crear la operacion</param>
        /// <returns>True si pudo crearse una nueva operacion, de lo contrario false</returns>
        /// <exception cref="ArgumentException">Si la lista de productos es nula o vacia
        /// lanza esta excepcion</exception>
        public static bool NuevaOperacion(List<Producto> productos)
        {
            if(productos is not null && productos.Count>0)
            {
                historial.Add(new Operacion(productos));
                return true;
            }
            throw new ArgumentException("No hay productos para agregar a la operacion");
        }
        /// <summary>
        /// Retira unidades de un producto del stock
        /// </summary>
        /// <param name="producto">Producto a retirar</param>
        /// <param name="cantidad">Cantidad de unaidades</param>
        /// <returns>Retorna true si pudo remover unidades, de lo contrario false</returns>
        public static bool RetirarDeStock(Producto producto, int cantidad)
        {
            if(producto is not null && cantidad >= 0)
            {
                if (stock == producto && stock[producto]-cantidad <= 0)
                {
                    stock[producto] -= cantidad;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Da de alta un proveedor
        /// </summary>
        /// <param name="proveedor">Proveedor a dar de alta</param>
        /// <returns>Retorna true si el proveedor pudo darse de alta exitosamente, de lo contrario
        /// false;</returns>
        public static bool AltaProveedor(Proveedor proveedor)
        {
            if(proveedor is not null)
            {
                proveedores.Add(proveedor);
                return true; 
            }
            return false;
        }
        /// <summary>
        /// Da de alta un producto
        /// </summary>
        /// <param name="producto">Producto a dar de alta</param>
        /// <returns>Retorna true si el producto pudo darse de alta exitosamente, de lo contrario
        /// false;</returns>
        public static bool AltaProducto(Producto producto, int cantidad)
        {
            if(producto is not null && cantidad >= 0)
            {
                stock.Add(producto, cantidad);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Guarda todas las listas en la ruta indicada
        /// </summary>
        /// <param name="ruta">Ruta en la cual almacenar los archivos</param>
        public static void Exportar(string ruta)
        {
            try
            {
                SerializadorXml<CableInterno> cables = new SerializadorXml<CableInterno>();
                SerializadorXml<ComponenteInterno> componentes = new SerializadorXml<ComponenteInterno>();
                SerializadorXml<ProveedorInterno> proveedores = new SerializadorXml<ProveedorInterno>();
                SerializadorXml<UsuarioInterno> empleados = new SerializadorXml<UsuarioInterno>();
                SerializadorJson<TareaInterna> tareas = new SerializadorJson<TareaInterna>();


                cables.Exportar(GetCablesInternos(), ruta,"Cables.xml");
                componentes.Exportar(GetComponentesInternos(),ruta, "Componentes.xml");
                proveedores.Exportar(GetProveedoresInternos(),ruta, "Proveedores.xml");
                empleados.Exportar(GetUsuariosInternos(), ruta, "Empleados.xml");
                tareas.Exportar(GetTareasInternas(), ruta, "Tareas.json");
                rutaGuardado = ruta;
                ArchivadorInterno.Escribir("init.txt", rutaGuardado);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Obtiene una lista de usuarios de uso interno
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        private static List<UsuarioInterno> GetUsuariosInternos()
        {
            List<UsuarioInterno> lista = new List<UsuarioInterno>();
            foreach(Usuario usuario in personal)
            {
                lista.Add(new UsuarioInterno(usuario));
            }
            return lista;
        }
        /// <summary>
        /// Obtiene una lista de proveedores de uso interno
        /// </summary>
        /// <returns>Lista de proveedores</returns>
        private static List<ProveedorInterno> GetProveedoresInternos()
        {
            List<ProveedorInterno> lista = new List<ProveedorInterno>();
            foreach (Proveedor proveedor in proveedores)
            {
                lista.Add(new ProveedorInterno(proveedor));
            }
            return lista;
        }
        /// <summary>
        /// Obtiene una lista de cables de uso interno
        /// </summary>
        /// <returns>Lista de cables</returns>
        private static List<CableInterno> GetCablesInternos()
        {
            List<CableInterno> lista = new List<CableInterno>();
            foreach (Producto producto in stock.Keys)
            {
                if(producto is Cable cable)
                {
                    lista.Add(new CableInterno(cable,stock[cable]));
                }
            }
            return lista;
        }
        /// <summary>
        /// Obtiene una lista de componentes de uso interno
        /// </summary>
        /// <returns>Lista de componentes</returns>
        private static List<ComponenteInterno> GetComponentesInternos()
        {
            List<ComponenteInterno> lista = new List<ComponenteInterno>();
            foreach (Producto producto in stock.Keys)
            {
                if(producto is Componente componente)
                {
                    lista.Add(new ComponenteInterno(componente, stock[componente]));
                }
            }
            return lista;
        }
        /// <summary>
        /// Obtiene una lista de tareas de uso interno
        /// </summary>
        /// <returns>Lista de tareas</returns>
        public static List<TareaInterna> GetTareasInternas()
        {
            List<TareaInterna> listaTareas = new List<TareaInterna>();
            foreach(Tarea tarea in tareas)
            {
                listaTareas.Add(new TareaInterna(tarea));
            }
            return listaTareas;
        }
        /// <summary>
        /// Carga todas las listas desde la última ruta utilizada para guardar
        /// </summary>
        public static void Importar()
        {
            SerializadorXml<UsuarioInterno> usuarios = new SerializadorXml<UsuarioInterno>();
            SerializadorXml<ProveedorInterno> proveedores = new SerializadorXml<ProveedorInterno>();
            SerializadorXml<CableInterno> cables = new SerializadorXml<CableInterno>();
            SerializadorXml<ComponenteInterno> componentes = new SerializadorXml<ComponenteInterno>();
            SerializadorJson<TareaInterna> tareas = new SerializadorJson<TareaInterna>();

            ImportarEmpleados(usuarios.Importar(rutaGuardado, "Empleados.xml"));
            ImportarCables(cables.Importar(rutaGuardado, "Cables.xml"));
            ImportarComponentes(componentes.Importar(rutaGuardado, "Componentes.xml"));
            ImportarProveedores(proveedores.Importar(rutaGuardado, "Proveedores.xml"));
            ImportarTareas(tareas.Importar(rutaGuardado, "Tareas.json"));
        }
        /// <summary>
        /// Carga los productos a la aplicacion usando una lista de uso interno
        /// </summary>
        /// <param name="lista">Lista de usuarios de uso interno</param>
        private static void ImportarEmpleados(List<UsuarioInterno> lista)
        {
            foreach(UsuarioInterno usuario in lista)
            {
                personal.Add(new Usuario(usuario));
            }
        }
        /// <summary>
        /// Carga los proveedores a la aplicacion usando una lista de uso interno
        /// </summary>
        /// <param name="lista">Lista de proveedores de uso interno</param>
        private static void ImportarProveedores(List<ProveedorInterno> lista)
        {
            foreach (ProveedorInterno proveedor in lista)
            {
                proveedores.Add(new Proveedor(proveedor));
            }
        }
        /// <summary>
        /// Carga los cables a la aplicacion usando una lista de uso interno
        /// </summary>
        /// <param name="lista">Lista de cables de uso interno</param>
        private static void ImportarCables(List<CableInterno> lista)
        {
            foreach (CableInterno cable in lista)
            {
                try
                {
                    stock.Add(new Cable(cable),cable.Cantidad);
                }
                catch(ArgumentException ex)
                {
                    throw new ArgumentException("El producto ya se encuentra en stock", ex);
                }
                catch(Exception ex)
                {
                    throw new Exception("Ocurrio un error inesperado", ex);
                }
            }
        }
        /// <summary>
        /// Carga los componentes a la aplicacion usando una lista de uso interno
        /// </summary>
        /// <param name="lista">Lista de componentes de uso interno</param>
        private static void ImportarComponentes(List<ComponenteInterno> lista)
        {
            foreach (ComponenteInterno componente in lista)
            {
                try
                {
                    stock.Add(new Componente(componente),componente.Cantidad);
                }
                catch (ArgumentException ex)
                {
                    throw new ArgumentException("El producto ya se encuentra en stock", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocurrio un error inesperado", ex);
                }
            }
        }
        /// <summary>
        /// Carga las tareas a la aplicacion usando una lista de uso interno
        /// </summary>
        /// <param name="listaTareas">Lista de tareas de uso interno</param>
        private static void ImportarTareas(List<TareaInterna> listaTareas)
        {
            foreach(TareaInterna tarea in listaTareas)
            {
                try
                {
                    tareas.Add(new Tarea(tarea));
                }
                catch (ArgumentException ex)
                {
                    throw new ArgumentException("El producto ya se encuentra en stock", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocurrio un error inesperado", ex);
                }
            }
        }

        public static bool NuevaTarea(string descripcion)
        {
            Tarea tarea = new Tarea(descripcion);
            tareas.Add(tarea);
            return tarea is not null;
        }

        public static void EditarTarea(object objeto, string descripcion)
        {
            if(objeto is Tarea tarea)
            {
                tarea.SetDescripcion(descripcion);
                return;
            }
            throw new ArgumentException("El elemento seleccionado no es una tarea");
        }

        public static void EliminarTarea(object objeto)
        {
            if(objeto is Tarea tarea)
            {
                tareas.Remove(tarea);
                return;
            }
            throw new ArgumentException("El objeto seleccionado no es una tarea");
        }

        public static void Cargar()
        {
            List<object[]> listaProductos = GestorBaseDatos.Consultar("PRODUCTOS", "*");
            List<object[]> listaEmpleados = GestorBaseDatos.Consultar("EMPLEADOS", "*");
            List<object[]> listaProveedores = GestorBaseDatos.Consultar("PROVEEDORES", "*");

            Cargar(listaEmpleados, ETipoCarga.Empleado);
            Cargar(listaProveedores, ETipoCarga.Proveedor);
            Cargar(listaProductos, ETipoCarga.Producto);
        }

        private static void Cargar(List<object[]> elementos, ETipoCarga tipoCarga)
        {
            try
            {
                switch (tipoCarga)
                {
                    case ETipoCarga.Producto:
                        Cargar(elementos, stock);
                        break;
                    case ETipoCarga.Proveedor:
                        Cargar(elementos, proveedores);
                        break;
                    case ETipoCarga.Empleado:
                        Cargar(elementos, personal);
                        break;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }  

        private static void Cargar(List<object[]> elementos, Dictionary<Producto,int> productos) 
        {
            foreach(object[] elemento in elementos)
            {
                //El sexto elemento en el array representa un tipo de dato único para cada tipo de producto. En el caso
                //de los cables, el sexto elemento es un booleano que representa si el cable posee doble aislacion,
                //almacenado como un bit en la base de datos. En el caso de los componentes representa la unidad de medicion

                if(int.TryParse(elemento[5].ToString(), out int dobleAislacion))
                {
                    Cable cable = new Cable();
                    productos.Add(cable.Cargar(elemento), (int)elemento[elemento.Length-1]);
                }
                else
                {
                    Componente componente = new Componente();
                    productos.Add(componente.Cargar(elemento), (int)elemento[elemento.Length - 1]);
                }
            }
        }

        private static void Cargar(List<object[]> elementos, List<Usuario> usuarios)
        {
            foreach(object[] elemento in elementos)
            {
                Usuario usuario = new Usuario();
                usuarios.Add(usuario.Cargar(elemento));
            }
        }

        private static void Cargar(List<object[]> elementos, List<Proveedor> proveedores)
        {
            foreach(object[] elemento in elementos)
            {
                Proveedor proveedor = new Proveedor();
                proveedores.Add(proveedor.Cargar(elemento));
            }
        }

        public static void Guardar()
        {
            List<ElementoStock<Producto>> listaProductos = GenenrarListaProductos();
            Guardar(listaProductos);
            Guardar<Usuario>(Personal, "EMPLEADOS");
            Guardar<Proveedor>(Proveedores, "PROVEEDORES");
            
        }

        private static List<ElementoStock<Producto>> GenenrarListaProductos()
        {
            List<ElementoStock<Producto>> listaProductos = new List<ElementoStock<Producto>>();
            foreach (var par in stock)
            {
                listaProductos.Add(new ElementoStock<Producto>(par));
            }
            return listaProductos;
        }

        private static void Guardar(List<ElementoStock<Producto>> lista)
        {
            string tabla = "PRODUCTOS";
            foreach (var item in lista)
            {
                if(GestorBaseDatos.ElementoExiste(tabla, item.Id.ToString()))
                {
                    GestorBaseDatos.Editar(tabla, GenerarCampos(item), $"@ID = {item.Id}");
                }
                else
                {
                    GestorBaseDatos.Insertar(tabla, "ID,DESCRIPCION,PRECIO,MARCA,CAMPO_1,CAMPO_2,ESTA_ACTIVO,CANTIDAD",
                                            item.APar().Key.GetValores());
                }
            }
        }

        private static void Guardar<T>(IEnumerable<T> lista, string tabla) where T : Persona
        {
            foreach (T item in lista)
            {
                if (GestorBaseDatos.ElementoExiste(tabla, item.Dni.ToString()))
                {
                    GestorBaseDatos.Editar(tabla, GenerarCampos(item), $"DNI = {item.Dni}");
                }
                else
                {
                    if(tabla == "PROVEEDORES")
                    {
                        GestorBaseDatos.Insertar(tabla, "NOMBRE,APELLIDO,DNI,PRODUCTOS,ESTA_ACTIVO",item.GetValores());
                    }
                    else
                    {
                        GestorBaseDatos.Insertar(tabla, "NOMBRE,APELLIDO,DNI,ADMINISTRADOR,USUARIO," +
                                                "CONTRASENIA,ESTA_ACTIVO",item.GetValores());
                    }

                }
            }
        }

        private static string GenerarCampos(ElementoStock<Producto> producto)
        {
            return producto.APar().Key.ActualizarValores() + $"CANTIDAD = {producto.APar().Value}";
        }

        private static string GenerarCampos(Persona persona)
        {
            return persona.ActualizarValores();
        }


    }
}
