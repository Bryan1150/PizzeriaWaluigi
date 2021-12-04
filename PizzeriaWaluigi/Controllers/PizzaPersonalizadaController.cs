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
            //IngredientesHandler accesoDatos = new IngredientesHandler();
            //ViewBag.ingredientes = accesoDatos.ObtenerTodosLosIngredientes();
            return View();
        }

        [HttpPost]
        public ActionResult crearPizza(string noticia)
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
                        ViewBag.Message = "La noticia" + " " + noticia + " fue creada con éxito :)";
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

        public ActionResult AgregarIngrediente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarIngrediente(IngredienteModel ingrediente)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    PizzaPersonalizadaHandler accesoDatos = new PizzaPersonalizadaHandler();
                    ViewBag.ExitoAlCrear = accesoDatos.InsertarIngrediente(ingrediente);
                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "El ingrediente" + " " + ingrediente.Nombre + " fue agregado a la base de datos.";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salió mal y no fue posible agregar el ingrediente.";
                return View();
            }
        }
    }
}