using Canguro.Core.Entities;
using CanguroWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CanguroWeb.Controllers
{
    public class CiudadController : Controller
    {
        
        public ActionResult Index()
        {
            List<Ciudad> ciudades = Ciudad.obtenerTodos();
            return View(ciudades);
        }
        public ActionResult Formulario(int id) {
            CiudadModel modelo = new CiudadModel();
            modelo.Ciudad = id != 0 ? Ciudad.obtenerId(id) : new Ciudad();
            modelo.Estados = Estado.obtenerTodos();
            return PartialView(modelo);
        }

        public ActionResult Guardar(int id, string nombre, int estado)
        {
            bool resultado = false;
            try{
                resultado = Ciudad.Guardar(id, nombre, estado);
            }
            catch (Exception ex){
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Eliminar(int id) {
            bool resultado = false;
            try {
                resultado = Ciudad.Eliminar(id);
            }
            catch (Exception ex) {
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}