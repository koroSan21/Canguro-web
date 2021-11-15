using Canguro.Core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canguro.Core.Entities
{
    public class Tramite
    {
        public int Id { get; set; }

        public string Nombre { get; set; }


        public static List<Tramite> obtenerTodos()
        {
            List<Tramite> tramites = new List<Tramite>();
            try
            {
                string query = "SELECT id, nombre FROM tramite";
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Tramite t = new Tramite();
                        t.Id = int.Parse(dataReader["id"].ToString());
                        t.Nombre = dataReader["nombre"].ToString();
                        tramites.Add(t);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tramites;
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
                    cmd.CommandText = "INSERT INTO tramite (nombre) VALUES (@nombre)";
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
