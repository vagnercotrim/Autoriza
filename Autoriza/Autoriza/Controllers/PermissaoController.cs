using Autoriza.DAO;
using Autoriza.Infra.NHibernate;
using System;
using System.Web.Mvc;
using Autoriza.Models;
using Autoriza.Models.Validation;
using FluentValidation.Results;

namespace Autoriza.Controllers
{
    public class PermissaoController : Controller
    {

        private PermissaoDAO PermissaoDAO;
        private SistemaDAO SistemaDAO;
        private PermissaoValidation validation;

        public PermissaoController(PermissaoDAO permissaoDAO, SistemaDAO sistemaDAO, PermissaoValidation validation)
        {
            PermissaoDAO = permissaoDAO;
            SistemaDAO = sistemaDAO;
            this.validation = validation;
        }

        public ActionResult Novo(int id)
        {
            Permissao permissao = new Permissao();
            permissao.Sistema = SistemaDAO.Get(id);

            return View(permissao);
        }

        [HttpPost]
        [Transaction]
        public ActionResult Novo([Bind(Exclude = "Id")]Permissao permissao)
        {
            try
            {
                permissao.Sistema = SistemaDAO.Get(permissao.Sistema.Id);

                ValidationResult result = validation.Validate(permissao);

                if (result.IsValid)
                {
                    PermissaoDAO.Save(permissao);

                    return RedirectToAction("Detalhar", "Sistema", new { id = permissao.Sistema.Id });
                }

                return View(permissao);
            }
            catch (Exception)
            {
                return View(permissao);
            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                Permissao permissao = PermissaoDAO.Get(id);

                return View(permissao);
            }
            catch (Exception)
            {
                return RedirectToAction("Detalhar", "Sistema", new { id = id });
            }
        }

        [HttpPost]
        [Transaction]
        public ActionResult Editar(Permissao permissao)
        {
            try
            {
                permissao.Sistema = SistemaDAO.Get(permissao.Sistema.Id);

                ValidationResult result = validation.Validate(permissao);

                if (result.IsValid)
                {
                    PermissaoDAO.Update(permissao);

                    return RedirectToAction("Detalhar", "Sistema", new { id = permissao.Sistema.Id });
                }

                return View(permissao);
            }
            catch (Exception)
            {
                return View(permissao);
            }
        }

    }
}