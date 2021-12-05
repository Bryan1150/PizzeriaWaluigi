using System.Web.Mvc;
using PizzeriaWaluigi.Models;
using PizzeriaWaluigi.Handlers;

namespace PizzeriaWaluigi.Controllers
{
    public class PizzaPersonalizadaController : Controller
    {
        public ActionResult PizzaPersonalizada()
        {
            PizzaPersonalizadaHandler accesoDatos = new PizzaPersonalizadaHandler();
            ViewBag.ingredientesDisponibles = accesoDatos.ObtenerTodosLosIngredientes();
            return View();
        }

        [HttpPost]
        public ActionResult PizzaPersonalizada(PizzaModel pizza)
        {
            ActionResult view = RedirectToAction("Envio_PagoDireccion", "Pagos", pizza);
            return view;
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
                    else
                    {
                        ViewBag.Message = "Algo salió mal y no fue posible agregar el ingrediente.";
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

        [HttpGet]
        public ActionResult ObtenerImagen(string nombreIngrediente)
        {
            PizzaPersonalizadaHandler ingredienteHandler = new PizzaPersonalizadaHandler();
            var tupla = ingredienteHandler.ObtenerFoto(nombreIngrediente);
            return File(tupla.Item1, tupla.Item2);
        }
    }
}