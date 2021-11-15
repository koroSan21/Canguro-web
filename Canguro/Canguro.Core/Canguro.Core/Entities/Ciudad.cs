using Canguro.Core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canguro.Core.Entities
{
    public class Ciudad{

        public int Id { get; set; }

        public string Nombre { get; set; }

        public Estado Estado { get; set; }

        public static List<Ciudad> obtenerTodos() {
            List<Ciudad> ciudades = new List<Ciudad>();
            try
            {
                string query = "SELECT c.id AS 'idCiudad', c.nombre AS 'ciudad', e.id AS 'idEstado', e.nombre AS 'estado' FROM ciudad c INNER JOIN estado e ON c.idEstado = e.id";
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Ciudad c = new Ciudad();
                        c.Id = int.Parse(dataReader["idCiudad"].ToString());
                        c.Nombre = dataReader["ciudad"].ToString();
                        

                        Estado e = new Estado();
                        e.Id = int.Parse(dataReader["idEstado"].ToString());
                        e.Nombre = dataReader["estado"].ToString();

                        c.Estado = e;

                        ciudades.Add(c);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ciudades;
        }

        public static Ciudad obtenerId(int id) {
            Ciudad c = new Ciudad();
            try
            {
                string query = "SELECT c.id AS 'idCiudad', c.nombre AS 'ciudad', e.id AS 'idEstado', e.nombre AS 'estado' FROM ciudad c INNER JOIN estado e ON c.idEstado = e.id WHERE c.id="+id;
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        
                        c.Id = int.Parse(dataReader["idCiudad"].ToString());
                        c.Nombre = dataReader["ciudad"].ToString();


                        Estado e = new Estado();
                        e.Id = int.Parse(dataReader["idEstado"].ToString());
                        e.Nombre = dataReader["estado"].ToString();

                        c.Estado = e;
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return c;
        }
        /// <summary>
        /// Guarda una ciudad en la base de datos
        /// </summary>
        /// <param name="id">Identificador de id en la base de datos</param>
        /// <param name="nombre"></param>
        /// <param name="estado"></param>
        /// <returns><see langword="true"/> Si el registro fue guardado correctamente, de lo contrario, <see langword="false"/></returns>
        public static bool Guardar(int id, string nombre, int estado) {
            bool esExitoso = false;
            try {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()) {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    if (id==0) {
                        cmd.CommandText = "INSERT INTO ciudad (nombre, idEstado) VALUES (@nombre,@estado)";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@estado", estado);
                        
                    }
                    else {
                        cmd.CommandText = "UPDATE ciudad SET nombre=@nombre, idEstado=@estado WHERE id=@idCiudad";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@estado", estado);
                        cmd.Parameters.AddWithValue("@idCiudad", id);

                    }
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

        public static bool Eliminar(int id) {
            bool esExitoso = false;
            try {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()) {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM ciudad WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    esExitoso = cmd.ExecuteNonQuery() == 1;

                    conexion.CloseConnection();
                }
            } catch(Exception ex) {
                throw ex;
            }
            return esExitoso;
        }
    }
}
