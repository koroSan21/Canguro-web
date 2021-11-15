using Canguro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CanguroWeb.Controllers
{
    public class ComprobanteDomicilioController : Controller
    {
        public ActionResult Index() {
            List<ComprobanteDomicilio> comprobantes = ComprobanteDomicilio.obtenerTodos();
            return View(comprobantes);
        }

        public ActionResult Formulario() {
            return PartialView();
        }

        public ActionResult Guardar(string nombre) {
            bool resultado = false;
            try {
                resultado = ComprobanteDomicilio.Guardar(nombre);
            } catch (Exception ex) {
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}