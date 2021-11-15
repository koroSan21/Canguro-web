using Canguro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canguro.Core.Transporte
{
    public class CitaDTO
    {
        public int Id { get; set; }

        public string Folio { get; set; }

        public string Ciudadano { get; set; }

        public string Modulo { get; set; }

        public string Fecha { get; set; }

        public string DocumentoNacionalidad { get; set; }

        public string ComprobanteDomicilio { get; set; }

        public string Tramite { get; set; }

        public CitaDTO Transformar(Cita c)
        {
            CitaDTO dto = new CitaDTO();
            dto.Id = c.Id;
            dto.Folio = c.Folio;
            dto.Ciudadano = c.Ciudadano != null ? (c.Ciudadano.Nombre + " " + c.Ciudadano.ApellidoPaterno + " " + c.Ciudadano.ApellidoMaterno) : "No asignado";
            dto.Modulo = c.Modulo != null ? (c.Modulo.Nombre) : "No asignado";
            dto.Fecha = c.Fecha.ToString("dd/MM/yyyy");
            dto.DocumentoNacionalidad = c.Documento != null ? (c.Documento.Nombre) : "No asignado";
            dto.ComprobanteDomicilio = c.Comprobante != null ? (c.Comprobante.Nombre) : "No asignado";
            dto.Tramite = c.Tramite != null ? (c.Tramite.Nombre) : "No asignado";

            return dto;

        }

        public List<CitaDTO> Transformar(List<Cita> citas) {
            List<CitaDTO> dto = new List<CitaDTO>();
            foreach(Cita c in citas)
            {
                dto.Add(Transformar(c));
            }
            return dto;
        }
    }   
}
