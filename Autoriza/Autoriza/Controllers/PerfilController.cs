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

        private readonly PerfilDAO perfilDAO;
        private readonly PermissaoDAO permissaoDAO;
        private readonly SistemaDAO sistemaDAO;
        private PermissoesDoPerfil permissoesDoPerfil;
        private PerfilValidation validation;

        public PerfilController(PerfilDAO perfilDAO, SistemaDAO sistemaDAO, PermissaoDAO permissaoDAO, PermissoesDoPerfil permissoesDoPerfil, PerfilValidation validation)
        {
            this.perfilDAO = perfilDAO;
            this.permissaoDAO = permissaoDAO;
            this.sistemaDAO = sistemaDAO;
            this.permissoesDoPerfil = permissoesDoPerfil;
            this.validation = validation;
        }

        public ActionResult Novo(int id)
        {
            Perfil perfil = new Perfil
            {
                Sistema = sistemaDAO.Get(id)
            };

            return View(perfil);
        }

        [HttpPost]
        [Transaction]
        public ActionResult Novo([Bind(Exclude = "Id")]Perfil perfil)
        {
            try
            {
                perfil.Sistema = sistemaDAO.Get(perfil.Sistema.Id);

                ValidationResult result = validation.Validate(perfil);

                if (result.IsValid)
                {
                    perfilDAO.Save(perfil);

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
            try
            {
                Perfil perfil = perfilDAO.Get(id);

                return View(perfil);
            }
            catch (Exception)
            {
                return RedirectToAction("Detalhar", "Sistema", new { id = id });
            }
        }

        [HttpPost]
        [Transaction]
        public ActionResult Editar(Perfil perfil)
        {
            try
            {
                perfil.Sistema = sistemaDAO.Get(perfil.Sistema.Id);
                ValidationResult result = validation.Validate(perfil);

                if (result.IsValid)
                {
                    perfilDAO.Update(perfil);

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
            Perfil perfil = perfilDAO.Get(id);
            ViewBag.permissoes = permissaoDAO.GetAllBySistema(perfil.Sistema.Id);

            return View(perfil);
        }

        [HttpPost]
        [Transaction]
        public ActionResult Permissoes(int id, int[] permissoes)
        {
            Perfil perfil = perfilDAO.Get(id);
            ViewBag.permissoes = permissaoDAO.GetAllBySistema(perfil.Sistema.Id);

            permissoesDoPerfil.Atualizar(perfil, permissoes);

            return View(perfil);
        }

    }
}