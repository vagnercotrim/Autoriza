using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autoriza.DAO;
using Autoriza.Models;
using Autoriza.Infra.NHibernate;

namespace Autoriza.Controllers
{
    public class PerfilController : Controller
    {

        private PerfilDAO PerfilDAO;
        private SistemaDAO SistemaDAO;

        public PerfilController(PerfilDAO perfilDAO, SistemaDAO sistemaDAO)
        {
            PerfilDAO = perfilDAO;
            SistemaDAO = sistemaDAO;
        }

        public ActionResult Novo(int id)
        {
            Perfil perfil = new Perfil();
            perfil.Sistema = SistemaDAO.Get(id);

            return View(perfil);
        }

        [HttpPost]
        [Transaction]
        public ActionResult Novo(Perfil perfil)
        {
            try
            {
                perfil.Sistema = SistemaDAO.Get(perfil.Sistema.Id);

                PerfilDAO.Save(perfil);

                return RedirectToAction("Detalhar", "Sistema", new { id = perfil.Sistema.Id });
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
                Perfil perfil = PerfilDAO.Get(id);

                return View(perfil);
            }
            catch (Exception)
            {
                return RedirectToAction("Detalhar", "Sistema", new {id = id});
            }
        }

        [HttpPost]
        [Transaction]
        public ActionResult Editar(Perfil perfil)
        {
            try
            {
                perfil.Sistema = SistemaDAO.Get(perfil.Sistema.Id);

                PerfilDAO.Update(perfil);

                return RedirectToAction("Detalhar", "Sistema", new { id = perfil.Sistema.Id });
            }
            catch (Exception)
            {
                return View(perfil);
            }
        }

    }
}