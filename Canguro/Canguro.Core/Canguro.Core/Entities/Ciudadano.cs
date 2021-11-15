using Canguro.Core.Database;
using Canguro.Core.Enums;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canguro.Core.Entities
{
    public class Ciudadano {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public TipoTelefono TipoTelefono { get; set; }

        public static List<Ciudadano> obtenerTodos()
        {
            List<Ciudadano> ciudadanos = new List<Ciudadano>();
            try
            {
                string query = "SELECT id, nombre, apellidoPaterno, apellidoMaterno, telefono, tipoTelefono, correo FROM ciudadano";
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Ciudadano c = new Ciudadano();
                        c.Id = int.Parse(dataReader["id"].ToString());
                        c.Nombre = dataReader["nombre"].ToString();
                        c.ApellidoPaterno = dataReader["apellidoPaterno"].ToString();
                        c.ApellidoMaterno = dataReader["apellidoMaterno"].ToString();
                        c.Telefono = dataReader["telefono"].ToString();
                        c.TipoTelefono = (TipoTelefono)int.Parse(dataReader["TipoTelefono"].ToString());
                        c.Correo = dataReader["correo"].ToString();

                        ciudadanos.Add(c);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ciudadanos;
        }
    }


}
