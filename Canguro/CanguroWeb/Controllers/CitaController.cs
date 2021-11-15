using Canguro.Core.Entities;
using Canguro.Core.Transporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CanguroWeb.Controllers
{
    public class CitaController : Controller
    {
        
        public ActionResult Index()
        {
            List<Cita> citas = Cita.obtenerTodos();

            CitaDTO citaDTO = new CitaDTO(); 

            return View(citaDTO.Transformar(citas));
        }
    }
}