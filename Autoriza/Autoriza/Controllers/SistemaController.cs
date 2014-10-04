using Autoriza.DAO;
using Autoriza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autoriza.Controllers
{
    public class SistemaController : Controller
    {

        private SistemaDAO SistemaDAO;

        public SistemaController(SistemaDAO sistemaDAO)
        {
            SistemaDAO = sistemaDAO;
        }

        public ActionResult Index()
        {
            IList<Sistema> sistemas = SistemaDAO.GetAll();

            return View(sistemas);
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Sistema sistema)
        {
            SistemaDAO.Save(sistema);

            return RedirectToAction("Index");
        }

    }
}