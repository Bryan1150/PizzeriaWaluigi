using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzeriaWaluigi.Models;
using PizzeriaWaluigi.Handlers;

namespace PizzeriaWaluigi.Controllers
{
    public class PizzaPersonalizadaController : Controller
    {
        public ActionResult crearPizza()
        {
            IngredientesHandler accesoDatos = new IngredientesHandler();
            ViewBag.ingredientes = accesoDatos.ObtenerTodosLosIngredientes();
            return View();
        }

        [HttpPost]
        public ActionResult crearPizza(PizzaModel noticia)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    //PizzaHandler accesoDatos = new NoticiasHandler();
                    //ViewBag.ExitoAlCrear = accesoDatos.InsertarNoticia(noticia);
                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "La noticia" + " " + noticia.Titulo + " fue creada con éxito :)";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salió mal y no fue posible crear la noticia :(";
                return View();
            }
        }
    }
}