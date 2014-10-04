using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autoriza.DAO;
using Autoriza.Models;

namespace Autoriza.Controllers
{
    public class HomeController : Controller
    {
        private SistemaDAO SistemaDAO;

        public HomeController(SistemaDAO sistemaDAO)
        {
            SistemaDAO = sistemaDAO;
        }

        public ActionResult Index()
        {
            Sistema sistema = SistemaDAO.Get(1);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}