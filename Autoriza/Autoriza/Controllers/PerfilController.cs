using System;
using System.Web.Mvc;
using Autoriza.DAO;
using Autoriza.Domain;
using Autoriza.Models;
using Autoriza.Infra.NHibernate;
using Autoriza.Models.Validation;
using FluentValidation.Results;

namespace Autoriza.Controllers
{
    public class PerfilController : Controller
    {

        private readonly PerfilDAO _perfilDao;
        private readonly PermissaoDAO _permissaoDao;
        private readonly SistemaDAO _sistemaDao;
        private readonly PermissoesDoPerfil _permissoesDoPerfil;
        private readonly PerfilValidation _validation;

        public PerfilController(PerfilDAO perfilDao, SistemaDAO sistemaDao, PermissaoDAO permissaoDao, PermissoesDoPerfil permissoesDoPerfil, PerfilValidation validation)
        {
            _perfilDao = perfilDao;
            _permissaoDao = permissaoDao;
            _sistemaDao = sistemaDao;
            _permissoesDoPerfil = permissoesDoPerfil;
            _validation = validation;
        }

        public ActionResult Novo(int id)
        {
            Sistema sistema = _sistemaDao.Get(id);

            if(sistema == null)
                return RedirectToAction("Index", "Sistema");

            var perfil = new Perfil(sistema);
            
            return View(perfil);
        }

        [HttpPost]
        [Transaction]
        public ActionResult Novo([Bind(Exclude = "Id")]Perfil perfil)
        {
            try
            {
                perfil.Sistema = _sistemaDao.Get(perfil.Sistema.Id);

                ValidationResult result = _validation.Validate(perfil);

                if (result.IsValid)
                {
                    _perfilDao.Save(perfil);

                    return RedirectToAction("Detalhar", "Sistema", new { id = perfil.Sistema.Id });
                }

                return View(perfil);
            }
            catch (Exception)
            {
                return View(perfil);
            }
        }

        public ActionResult Editar(int id)
        {
            Perfil perfil = _perfilDao.Get(id);

            if (perfil == null)
                return RedirectToAction("Index", "Sistema");

            return View(perfil);
        }

        [HttpPost]
        [Transaction]
        public ActionResult Editar(Perfil perfil)
        {
            try
            {
                perfil.Sistema = _sistemaDao.Get(perfil.Sistema.Id);
                ValidationResult result = _validation.Validate(perfil);

                if (result.IsValid)
                {
                    _perfilDao.Update(perfil);

                    return RedirectToAction("Detalhar", "Sistema", new { id = perfil.Sistema.Id });
                }

                return View(perfil);
            }
            catch (Exception)
            {
                return View(perfil);
            }
        }

        public ActionResult Permissoes(int id)
        {
            Perfil perfil = _perfilDao.Get(id);
            ViewBag.permissoes = _permissaoDao.GetAllBySistema(perfil.Sistema.Id);

            return View(perfil);
        }

        [HttpPost]
        [Transaction]
        public ActionResult Permissoes(int id, int[] permissoes)
        {
            Perfil perfil = _perfilDao.Get(id);
            ViewBag.permissoes = _permissaoDao.GetAllBySistema(perfil.Sistema.Id);

            _permissoesDoPerfil.Atualizar(perfil, permissoes);

            return View(perfil);
        }

    }
}