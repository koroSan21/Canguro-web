using Canguro.Core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canguro.Core.Entities
{
    public class DocumentoNacionalidad
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public static List<DocumentoNacionalidad> obtenerTodos()
        {
            List<DocumentoNacionalidad> documentos = new List<DocumentoNacionalidad>();
            try
            {
                string query = "SELECT id, nombre FROM documento_nacionalidad";
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        DocumentoNacionalidad d = new DocumentoNacionalidad();
                        d.Id = int.Parse(dataReader["id"].ToString());
                        d.Nombre = dataReader["nombre"].ToString();
                        documentos.Add(d);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return documentos;
        }

        public static bool Guardar(string nombre)
        {
            bool esExitoso = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO documento_nacionalidad (nombre) VALUES (@nombre)";
                    cmd.Parameters.AddWithValue("@nombre", nombre);

                    esExitoso = cmd.ExecuteNonQuery() == 1;

                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return esExitoso;
        }

    }
}
