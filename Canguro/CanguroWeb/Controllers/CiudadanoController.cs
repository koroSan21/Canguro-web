using Canguro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CanguroWeb.Controllers
{
    public class CiudadanoController : Controller
    {
        
        public ActionResult Index()
        {
            List<Ciudadano> ciudadanos = Ciudadano.obtenerTodos();
            return View(ciudadanos);
        }
    }
}