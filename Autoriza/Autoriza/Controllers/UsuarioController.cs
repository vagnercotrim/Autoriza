using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Autoriza.DAO;
using Autoriza.Infra.NHibernate;
using Autoriza.Models;
using Autoriza.Models.Validation;
using FluentValidation.Results;

namespace Autoriza.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly UsuarioDAO _usuarioDao;
        private readonly UsuarioValidation _validation;

        public UsuarioController(UsuarioDAO usuarioDao, UsuarioValidation validation)
        {
            _usuarioDao = usuarioDao;
            _validation = validation;
        }

        public ActionResult Index()
        {
            IList<Usuario> usuarios = _usuarioDao.GetAll();

            return View(usuarios);
        }

        public ActionResult Novo()
        {
            return View();
        }
        
        [HttpPost]
        [Transaction]
        public ActionResult Novo(Usuario usuario)
        {
            try
            {
                ValidationResult result = _validation.Validate(usuario);

                if (result.IsValid)
                {
                    _usuarioDao.Save(usuario);

                    return RedirectToAction("Index", "Usuario", new { id = usuario.Id });
                }

                return View(usuario);

            }
            catch (Exception)
            {
                return View(usuario);
            }
        }

        public ActionResult Editar(int id)
        {
            Usuario usuario = _usuarioDao.Get(id);

            if (usuario == null)
                return RedirectToAction("Index", "Sistema");

            return View(usuario);
        }

        [HttpPost]
        [Transaction]
        public ActionResult Editar(Usuario usuario)
        {
            try
            {
                Usuario noBanco = _usuarioDao.Get(usuario.Id);
                noBanco.Atualiza(usuario);

                ValidationResult result = _validation.Validate(noBanco);

                if (result.IsValid)
                {
                    _usuarioDao.Update(noBanco);

                    return RedirectToAction("Index");
                }

                return View(usuario);

            }
            catch (Exception)
            {
                return View(usuario);
            }
        }

        public ActionResult Detalhar(int id)
        {
            Usuario usuario = _usuarioDao.Get(id);

            if (usuario == null)
                return RedirectToAction("Index", "Usuario");

            return View(usuario);
        }

    }
}