using Canguro.Core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canguro.Core.Entities {
    /// <summary>
    /// Representa los atributos y métodos correspondientes a la cita que realiza el ciudadano para realizar su trámite
    /// </summary>
    public class Cita{
        public int Id { get; set; }

        public string Folio { get; set; }

        public Ciudadano Ciudadano { get; set; }

        public Modulo Modulo { get; set; }

        public DateTime Fecha { get; set; }

        public DocumentoNacionalidad Documento { get; set; }

        public ComprobanteDomicilio Comprobante { get; set; }

        public Tramite Tramite { get; set; }

        public static List<Cita> obtenerTodos()
        {
            List<Cita> citas = new List<Cita>();
            try
            {
                string query = "SELECT c.id AS 'idCita', c.folio AS 'folio',  c.fecha AS 'fecha', ci.nombre AS 'ciudadano', ci.apellidoPaterno AS 'apellidoPaterno', ci.apellidoMaterno AS 'apellidoMaterno', m.nombre AS 'modulo', d.nombre AS 'documento', co.nombre AS 'comprobante', t.nombre AS 'tramite' FROM cita c INNER JOIN ciudadano ci ON c.idCiudadano = ci.id INNER JOIN modulo m ON c.idModulo = m.id INNER JOIN documento_nacionalidad d ON c.idDocumento = d.id INNER JOIN comprobante_domicilio co ON c.idComprobante = co.id INNER JOIN tramite t ON c.idTramite = t.id";
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Cita cita = new Cita();
                        cita.Id = int.Parse(dataReader["idCita"].ToString());
                        cita.Folio = dataReader["folio"].ToString();
                        cita.Fecha = DateTime.Parse(dataReader["fecha"].ToString());

                        Ciudadano c = new Ciudadano();
                        c.Nombre = dataReader["ciudadano"].ToString();
                        c.ApellidoPaterno = dataReader["apellidoPaterno"].ToString();
                        c.ApellidoMaterno = dataReader["apellidoMaterno"].ToString();
                        cita.Ciudadano = c;

                        Modulo m = new Modulo();
                        m.Nombre = dataReader["modulo"].ToString();
                        cita.Modulo = m;

                        DocumentoNacionalidad d = new DocumentoNacionalidad();
                        d.Nombre = dataReader["documento"].ToString();
                        cita.Documento = d;

                        ComprobanteDomicilio co = new ComprobanteDomicilio();
                        co.Nombre = dataReader["comprobante"].ToString();
                        cita.Comprobante = co;

                        Tramite t = new Tramite();
                        t.Nombre = dataReader["tramite"].ToString();
                        cita.Tramite = t;

                        citas.Add(cita);
                    }

                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return citas;
        }

    }
}
