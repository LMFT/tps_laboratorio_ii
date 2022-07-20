using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Interfaces;

namespace Almacenamiento
{
    public static class GestorBaseDatos
    {
        private static SqlConnection sqlConnection;

        public static bool ConexionEstablecida { get => sqlConnection is not null; }

        static GestorBaseDatos()
        {
            Conectar(".", "KAUFMANN_DB");
        }

        public static bool Conectar(string servidor, string baseDatos)
        {
            try
            {
                sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = $"Server = {servidor}; Database = {baseDatos}; Trusted_Connection = True;";
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Se produjo un error inesperado: {ex.Message}", ex);
            }
        }

        public static int Insertar(string tabla, string campos, string valores)
        {
            if(tabla is null || campos is null || valores is null)
            {
                throw new ArgumentNullException("Uno de los parametros requeridos para esta funcion esta vacio");
            }
            SqlCommand comando = new SqlCommand();
            comando.Connection = sqlConnection;
            string[] campos2 = campos.Split(',');
            string[] valores2 = valores.Split(',');

            string textoComando = $"INSERT INTO {tabla} ({campos}) ({valores}) (";

            for(int i = 0; i < campos2.Length; i++)
            {
                comando.Parameters.AddWithValue(campos2[i], valores2[i]);
                textoComando += $"{valores2[i]}";
                if(i != campos2.Length - 1)
                {
                    textoComando+=',';
                }
            }
            textoComando+=')';
            comando.CommandText = textoComando.ToString();
            try
            {
                return EjecutarComando(comando);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static int Editar(string tabla, string campos, string condicion)
        {
            if(tabla is null || campos is null || condicion is null)
            {
                throw new ArgumentNullException("Uno de los parametros requeridos para esta funcion esta vacio");
            }
            SqlCommand comando = new SqlCommand();
            comando.Connection = sqlConnection;
            string[] campos2 = campos.Split(',');

            string textoComando = $"UPDATE {tabla} ";
            textoComando+="SET ";
            for(int i = 0; i < campos2.Length; i++)
            {
                string[] valores = campos2[i].Split('=');
                if(!valores[0].StartsWith('@'))
                {
                    valores[0].Insert(0, "@");
                }
                comando.Parameters.AddWithValue(valores[0], valores[1]);
                textoComando += $"{valores[0]} = {valores[1]}";

                if(i != campos2.Length - 1)
                {
                    textoComando += ',';
                }

            }
            textoComando+=($"\nWHERE {condicion}");
            comando.CommandText = textoComando;
            try
            {
                return EjecutarComando(comando);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int BajaFisica(string tabla,string campo, string valor)
        {
            string textoComando = $"DELETE FROM {tabla} WHERE {campo} = {valor}";
            SqlCommand comando = new SqlCommand(textoComando);
            comando.Connection = sqlConnection;
            comando.Parameters.AddWithValue(campo, valor);
            try
            {
                return EjecutarComando(comando);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<object[]> Consultar(string campos,string tabla ,string datos)
        {
            string textoComando = $"SELECT {campos} FROM {tabla} WHERE {datos}";
            SqlCommand comando = new SqlCommand(textoComando);
            comando.Connection = sqlConnection;
            List<object[]> lista = new List<object[]>();
            try
            {
                sqlConnection.Open();
                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        object[] elementos = new object[dataReader.FieldCount];
                        string[] campos2 = campos.Split(',');
                        int i = 0;
                        foreach(string campo in campos2)
                        {
                            elementos[i] = dataReader[campos2[i]].ToString();
                        }
                        lista.Add(elementos);
                    }
                }
                return lista;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public static List<object[]> ConsultarEmpleados()
        {
            string textoComando = $"SELECT * FROM EMPLEADOS";

            SqlCommand comando = new SqlCommand(textoComando);
            comando.Connection = sqlConnection;

            List<object[]> lista = new List<object[]>();
            try
            {
                sqlConnection.Open();
                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        object[] elementos = new object[dataReader.FieldCount];
                        elementos[0] = dataReader["NOMBRE"].ToString();
                        elementos[1] = dataReader["APELLIDO"].ToString();
                        elementos[2] = (int)dataReader["DNI"];
                        elementos[3] = (int)dataReader["ADMINISTRADOR"];
                        elementos[4] = dataReader["USUARIO"].ToString();
                        elementos[5] = dataReader["CONTRASENIA"].ToString();
                        lista.Add(elementos);
                    }
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public static List<object[]> ConsultarProductos()
        {
            string textoComando = $"SELECT * FROM PRODUCTOS";

            SqlCommand comando = new SqlCommand(textoComando);
            comando.Connection = sqlConnection;

            List<object[]> lista = new List<object[]>();
            try
            {
                sqlConnection.Open();
                using (SqlDataReader dataReader = comando.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        object[] elementos = new object[dataReader.FieldCount];
                        elementos[0] = dataReader["ID"].ToString();
                        elementos[1] = dataReader["DESCRIPCION"].ToString();
                        elementos[2] = (int)dataReader["PRECIO"];
                        elementos[3] = (int)dataReader["MARCA"];
                        elementos[4] = dataReader["CAMPO_1"].ToString();
                        elementos[5] = dataReader["CAMPO_2"].ToString();
                        elementos[6] = dataReader["CANTIDAD"].ToString();
                        lista.Add(elementos);
                    }
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private static int EjecutarComando(SqlCommand comando)
        {
            try
            {
                sqlConnection.Open();
                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas;
            }
            catch(Exception ex)
            {
                throw new Exception($"Se produjo un error inesperado: {ex.Message}", ex);
            }
            finally
            {
                comando.Parameters.Clear();
                sqlConnection.Close();
            }
        }

        public static bool ElementoExiste(string campos,string tabla, string datos)
        {
            List<object[]> lista = Consultar(campos,tabla, datos);
            return lista is not null && lista.Count > 0 && !lista.Contains(null);
        } 
    }
}
