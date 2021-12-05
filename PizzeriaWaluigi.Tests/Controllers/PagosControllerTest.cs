using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PizzeriaWaluigi.Controllers;
using PizzeriaWaluigi.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace PizzeriaWaluigi.Tests.Controllers
{
    [TestClass]
    public class PagosControllerTest
    {
        [TestMethod]
        public void TestEnvioPagoDatosActionResultNotNull()
        {
            PagosController PagosController = new PagosController();
            ActionResult vista = PagosController.Envio_PagoDatos();
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestEnvioPagoDireccionActionResultNotNull()
        {
            PagosController PagosController = new PagosController();
            ActionResult vista = PagosController.Envio_PagoDireccion();
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestEnvioPagoDatosViewResult()
        {
            PagosController PagosController = new PagosController();
            ViewResult vista = PagosController.Envio_PagoDatos() as ViewResult;
            Assert.AreEqual("Envio_PagoDatos", vista.ViewName);
        }

        [TestMethod]
        public void TestEnvioPagoDireccionProductoViewResult()
        {
            PagosController PagosController = new PagosController();
            ViewResult vista = PagosController.Envio_PagoDireccion() as ViewResult;
            Assert.AreEqual("Envio_PagoDireccion", vista.ViewName);
        }
    }
}
