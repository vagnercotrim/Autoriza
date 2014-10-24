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

        private readonly PermissaoDAO _permissaoDao;
        private readonly SistemaDAO _sistemaDao;
        private readonly PermissaoValidation _validation;

        public PermissaoController(PermissaoDAO permissaoDao, SistemaDAO sistemaDao, PermissaoValidation validation)
        {
            _permissaoDao = permissaoDao;
            _sistemaDao = sistemaDao;
            _validation = validation;
        }

        public ActionResult Novo(int id)
        {
            Permissao permissao = new Permissao { Sistema = _sistemaDao.Get(id) };

            return View(permissao);
        }

        [HttpPost]
        [Transaction]
        public ActionResult Novo([Bind(Exclude = "Id")]Permissao permissao)
        {
            try
            {
                permissao.Sistema = _sistemaDao.Get(permissao.Sistema.Id);

                ValidationResult result = _validation.Validate(permissao);

                if (result.IsValid)
                {
                    _permissaoDao.Save(permissao);

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
            Permissao permissao = _permissaoDao.Get(id);

            if (permissao == null)
                return RedirectToAction("Index", "Sistema");

            return View(permissao);
        }

        [HttpPost]
        [Transaction]
        public ActionResult Editar(Permissao permissao)
        {
            try
            {
                permissao.Sistema = _sistemaDao.Get(permissao.Sistema.Id);

                ValidationResult result = _validation.Validate(permissao);

                if (result.IsValid)
                {
                    _permissaoDao.Update(permissao);

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