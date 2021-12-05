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
    public class MenuControllerTest
    {
        [TestMethod]
        public void TestMenuActionResultNotNull()
        {
            MenuController MenuController = new MenuController();
            ActionResult vista = MenuController.Menu();
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestAgregarProductoActionResultNotNull()
        {
            MenuController PizzaPersonalizadaController = new MenuController();
            ActionResult vista = PizzaPersonalizadaController.AgregarProducto();
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestMenuViewResult()
        {
            MenuController MenuController = new MenuController();
            ViewResult vista = MenuController.Menu() as ViewResult;
            Assert.AreEqual("Menu", vista.ViewName);
        }

        [TestMethod]
        public void TestAgregarProductoViewResult()
        {
            MenuController MenuController = new MenuController();
            ViewResult vista = MenuController.AgregarProducto() as ViewResult;
            Assert.AreEqual("AgregarProducto", vista.ViewName);
        }
    }
}
