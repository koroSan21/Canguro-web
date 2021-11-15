using Canguro.Core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canguro.Core.Entities
{
    public class Modulo
    {
        public int Id { get; set;}
        public string Nombre { get; set;}

        public Ciudad Ciudad { get; set;}

        public string Direccion { get; set; }

        public string Referencia { get; set; }

        public string Horario { get; set; }

        public static List<Modulo> obtenerTodos()
        {
            List<Modulo> modulos = new List<Modulo>();
            try
            {
                string query = "SELECT m.id AS 'idModulo', m.nombre AS 'modulo', c.id AS 'idCiudad', m.direccion AS 'direccion', m.referencia AS 'referencia', m.horario AS 'horario', c.nombre AS 'ciudad' FROM modulo m INNER JOIN ciudad c ON m.idCiudad = c.id";
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Modulo m = new Modulo();
                        m.Id = int.Parse(dataReader["idModulo"].ToString());
                        m.Nombre = dataReader["modulo"].ToString();
                        m.Direccion = dataReader["direccion"].ToString();
                        m.Referencia = dataReader["referencia"].ToString();
                        m.Horario = dataReader["horario"].ToString();


                        Ciudad c = new Ciudad();
                        c.Id = int.Parse(dataReader["idCiudad"].ToString());
                        c.Nombre = dataReader["ciudad"].ToString();

                        m.Ciudad = c;

                        modulos.Add(m);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return modulos;
        }
    }
}
