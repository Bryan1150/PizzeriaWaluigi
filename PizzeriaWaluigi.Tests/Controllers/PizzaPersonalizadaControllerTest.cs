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
    public class PizzeriaControllerTest
    {
        [TestMethod]
        public void TestPizzaPersonalizadaActionResultNotNull()
        {
            PizzaPersonalizadaController PizzaPersonalizadaController = new PizzaPersonalizadaController();
            ActionResult vista = PizzaPersonalizadaController.PizzaPersonalizada();
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestAgregarIngredienteActionResultNotNull()
        {
            PizzaPersonalizadaController PizzaPersonalizadaController = new PizzaPersonalizadaController();
            ActionResult vista = PizzaPersonalizadaController.AgregarIngrediente();
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestPizzaPersonalizadaViewResult()
        {
            PizzaPersonalizadaController PizzaPersonalizadaController = new PizzaPersonalizadaController();
            ViewResult vista = PizzaPersonalizadaController.PizzaPersonalizada() as ViewResult;
            Assert.AreEqual("PizzaPersonalizada", vista.ViewName);
        }

        [TestMethod]
        public void TestAgregarIngredienteViewResult()
        {
            PizzaPersonalizadaController PizzaPersonalizadaController = new PizzaPersonalizadaController();
            ViewResult vista = PizzaPersonalizadaController.AgregarIngrediente() as ViewResult;
            Assert.AreEqual("AgregarIngrediente", vista.ViewName);
        }      
    }
}
