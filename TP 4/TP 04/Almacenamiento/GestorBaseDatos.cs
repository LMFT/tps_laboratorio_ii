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
                sqlConnection = new SqlConnection($"Server = {servidor}; Database = {baseDatos}; Trusted_Connection = True;");
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
            string[] campos2 = campos.Split(',');
            string[] valores2 = valores.Split(',');

            StringBuilder sb = new StringBuilder($"INSERT INTO {tabla} ({campos}) ({valores}) (");

            for(int i = 0; i < campos2.Length; i++)
            {
                comando.Parameters.AddWithValue(campos2[i], valores2[i]);
                sb.Append($"{valores2[i]}");
                if(i != campos2.Length - 1)
                {
                    sb.Append(',');
                }
            }
            sb.Append(')');
            comando.CommandText = sb.ToString();
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
            StringBuilder sb = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            string[] campos2 = campos.Split(',');
            sb.AppendLine($"UPDATE {tabla} ");
            sb.AppendLine("SET ");
            for(int i = 0; i < campos2.Length; i++)
            {
                string[] valores = campos2[i].Split('=');
                if(!valores[0].StartsWith('@'))
                {
                    valores[0].Insert(0, "@");
                }
                comando.Parameters.AddWithValue(valores[0], valores[1]);
            }
            sb.AppendLine($"\nWHERE {condicion}");
            comando.CommandText = sb.ToString();
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
            StringBuilder sb = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue(campo, valor);
            sb.AppendLine($"DELETE FROM {tabla} WHERE {campo} = {valor}");
            try
            {
                return EjecutarComando(comando);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<object[]> Consultar(string tabla ,string datos)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"SELECT {datos} FROM {tabla}");
            SqlCommand comando = new SqlCommand(sb.ToString());
            List<object[]> lista = new List<object[]>();
            using (SqlDataReader dataReader = comando.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    object[] elementos = new object[dataReader.FieldCount];
                    lista.Add(elementos);
                }
            }
            return lista;
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

        public static bool ElementoExiste(string tabla, string datos)
        {
            List<object[]> lista = Consultar(tabla, datos);
            return lista is not null && lista.Count > 0;
        } 
    }
}
