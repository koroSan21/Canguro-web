using Canguro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CanguroWeb.Controllers
{
    public class ModuloController : Controller
    {
        
        public ActionResult Index()
        {
            List<Modulo> modulos = Modulo.obtenerTodos();
            return View(modulos);
        }
    }
}