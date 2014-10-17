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

        private readonly SistemaDAO _sistemaDao;
        private readonly SistemaValidation _validation;

        public SistemaController(SistemaDAO sistemaDao, SistemaValidation validation)
        {
            _sistemaDao = sistemaDao;
            _validation = validation;
        }

        public ActionResult Index()
        {
            IList<Sistema> sistemas = _sistemaDao.GetAll();

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
                ValidationResult result = _validation.Validate(sistema);

                if (result.IsValid)
                {
                    _sistemaDao.Save(sistema);

                    return RedirectToAction("Detalhar", "Sistema", new { id = sistema.Id });
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
            Sistema sistema = _sistemaDao.Get(id);

            if (sistema == null)
                return RedirectToAction("Index", "Sistema");

            return View(sistema);
        }

        [HttpPost]
        [Transaction]
        public ActionResult Editar(Sistema sistema)
        {
            try
            {
                Sistema noBanco = _sistemaDao.Get(sistema.Id);

                sistema.Perfis = noBanco.Perfis;
                sistema.Permissoes = noBanco.Permissoes;
                sistema.ChaveAcesso = noBanco.ChaveAcesso;

                ValidationResult result = _validation.Validate(sistema);

                if (result.IsValid)
                {
                    _sistemaDao.Update(noBanco);

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
            Sistema sistema = _sistemaDao.Get(id);

            if (sistema == null)
                return RedirectToAction("Index", "Sistema");

            return View(sistema);
        }
    }
}