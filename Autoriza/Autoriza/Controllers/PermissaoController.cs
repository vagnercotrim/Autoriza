using Autoriza.DAO;
using Autoriza.Infra.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autoriza.Models;

namespace Autoriza.Controllers
{
    public class PermissaoController : Controller
    {
        
        private PermissaoDAO PermissaoDAO;
        private SistemaDAO SistemaDAO;

        public PermissaoController(PermissaoDAO permissaoDAO, SistemaDAO sistemaDAO)
        {
            PermissaoDAO = permissaoDAO;
            SistemaDAO = sistemaDAO;
        }

        public ActionResult Novo(int id)
        {
            Permissao permissao = new Permissao();
            permissao.Sistema = SistemaDAO.Get(id);

            return View(permissao);
        }

        [HttpPost]
        [Transaction]
        public ActionResult Novo(Permissao permissao)
        {
            try
            {
                permissao.Sistema = SistemaDAO.Get(permissao.Sistema.Id);

                PermissaoDAO.Save(permissao);

                return RedirectToAction("Detalhar", "Sistema", new { id = permissao.Sistema.Id });
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

                PermissaoDAO.Update(permissao);

                return RedirectToAction("Detalhar", "Sistema", new { id = permissao.Sistema.Id });
            }
            catch (Exception)
            {
                return View(permissao);
            }
        }

    }
}