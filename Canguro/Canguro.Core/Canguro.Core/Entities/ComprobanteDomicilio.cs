using Canguro.Core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canguro.Core.Entities
{
    public class ComprobanteDomicilio{
        public int Id { get; set; }

        public string Nombre { get; set; }

        public static List<ComprobanteDomicilio> obtenerTodos()
        {
            List<ComprobanteDomicilio> comprobantes = new List<ComprobanteDomicilio>();
            try
            {
                string query = "SELECT id, nombre FROM Comprobante_domicilio";
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        ComprobanteDomicilio c = new ComprobanteDomicilio();
                        c.Id = int.Parse(dataReader["id"].ToString());
                        c.Nombre = dataReader["nombre"].ToString();
                        comprobantes.Add(c);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return comprobantes;
        }
        public static bool Guardar(string nombre) {
            bool esExitoso = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO comprobante_domicilio (nombre) VALUES (@nombre)";
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
