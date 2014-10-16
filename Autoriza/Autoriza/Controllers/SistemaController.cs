using Autoriza.DAO;
using Autoriza.Infra.NHibernate;
using Autoriza.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Autoriza.Models.Validation;
using FluentValidation.Results;

namespace Autoriza.Controllers
{
    public class SistemaController : Controller
    {

        private SistemaDAO SistemaDAO;
        private SistemaValidation validation;

        public SistemaController(SistemaDAO sistemaDAO, SistemaValidation validation)
        {
            SistemaDAO = sistemaDAO;
            this.validation = validation;
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
                ValidationResult result = validation.Validate(sistema);

                if (result.IsValid)
                {
                    SistemaDAO.Save(sistema);

                    return RedirectToAction("Index");
                }

                return View(sistema);

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

                sistema.Perfis = noBanco.Perfis;
                sistema.Permissoes = noBanco.Permissoes;
                sistema.ChaveAcesso = noBanco.ChaveAcesso;
                
                ValidationResult result = validation.Validate(sistema);

                if (result.IsValid)
                {
                    SistemaDAO.Update(noBanco);

                    return RedirectToAction("Index");
                }

                return View(sistema);

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