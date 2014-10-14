using Autoriza.DAO;
using Autoriza.Infra;
using Autoriza.Infra.NHibernate;
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
        [Transaction]
        public ActionResult Novo(Sistema sistema)
        {
            try
            {
                SistemaDAO.Save(sistema);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(sistema);
            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                Sistema sistema = SistemaDAO.Get(id);
                
                return View(sistema);        
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Transaction]
        public ActionResult Editar(Sistema sistema)
        {
            try
            {
                Sistema noBanco = SistemaDAO.Get(sistema.Id);
                noBanco.Nome = sistema.Nome;
                noBanco.Url = sistema.Url;

                SistemaDAO.Update(noBanco);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(sistema);
            }
        }

        public ActionResult Detalhar(int id)
        {
            try
            {
                Sistema sistema = SistemaDAO.Get(id);

                return View(sistema);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}