using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzeriaWaluigi.Models;
using PizzeriaWaluigi.Handlers;

namespace PizzeriaWaluigi.Controllers
{
    public class PagosController : Controller
    {
        // GET: Pagos
        public ActionResult Envio_PagoDireccion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Envio_PagoDireccion(FacturaModel factura)
        {
            ActionResult view = RedirectToAction("Envio_PagoDatos", "Pagos", factura);
            return View();
        }

        public ActionResult Envio_PagoDatos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Envio_PagoDatos(FacturaModel factura)
        {

            return View();
        }
    }
}