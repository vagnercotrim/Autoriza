using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Autoriza.DAO;
using Autoriza.Infra.NHibernate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autoriza;
using Autoriza.Controllers;
using NHibernate;

namespace Autoriza.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        private SistemaDAO CreateSistemaDao()
        {
            ISession session = new SessionFactory().CreateSessionFactory().OpenSession();
            SistemaDAO dao = new SistemaDAO(session);
            return dao;
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            var dao = CreateSistemaDao();

            HomeController controller = new HomeController(dao);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            var dao = CreateSistemaDao();

            HomeController controller = new HomeController(dao);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            var dao = CreateSistemaDao();

            HomeController controller = new HomeController(dao);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
