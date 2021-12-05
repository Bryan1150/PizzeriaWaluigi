using PizzeriaWaluigi.Handlers;
using PizzeriaWaluigi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzeriaWaluigi.Controllers
{
    public class MenuController : Controller
    {
        public ActionResult Menu()
        {
            MenuHandler accesoDatos = new MenuHandler();
            ViewBag.productosDisponibles = accesoDatos.ObtenerTodosLosProductos();
            return View();
        }

        public ActionResult AgregarProducto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarProducto(ProductoModel producto)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    MenuHandler accesoDatos = new MenuHandler();
                    ViewBag.ExitoAlCrear = accesoDatos.InsertarProducto(producto);
                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "El producto" + " " + producto.Nombre + " fue agregado a la base de datos.";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Message = "Algo salió mal y no fue posible agregar el producto.";
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salió mal y no fue posible agregar el producto.";
                return View();
            }
        }

        [HttpGet]
        public ActionResult ObtenerImagen(string nombreIngrediente)
        {
            PizzaPersonalizadaHandler ingredienteHandler = new PizzaPersonalizadaHandler();
            var tupla = ingredienteHandler.ObtenerFoto(nombreIngrediente);
            return File(tupla.Item1, tupla.Item2);
        }
    }
}