using Canguro.Core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canguro.Core.Entities{
    
    public class Estado{

        public int Id { get; set; }

        public string Nombre { get; set; }


        public static List<Estado> obtenerTodos() {
            List<Estado> estados = new List<Estado>();
            try {
                string query = "SELECT id, nombre FROM estado";
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()){
                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                
                    while (dataReader.Read()){
                        Estado e = new Estado();
                        e.Id = int.Parse(dataReader["id"].ToString());
                        e.Nombre = dataReader["nombre"].ToString();
                        estados.Add(e);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }
            } catch(Exception ex) {
                throw ex;
            }
            return estados;
        }
        
        public static bool Guardar(string nombre) {
            bool esExitoso = false;
            try{
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()) {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO estado (nombre) VALUES (@nombre)";
                    cmd.Parameters.AddWithValue("@nombre", nombre);

                    /*
                    if (cmd.ExecuteNonQuery() == 1) {
                        esExitoso = true;
                    }
                    else {
                        esExitoso = false;
                    }
                    */

                    esExitoso=cmd.ExecuteNonQuery() == 1;

                    conexion.CloseConnection();
                }
            }
            catch(Exception ex){
                throw ex;
            }
            return esExitoso;
        }
    }
}
