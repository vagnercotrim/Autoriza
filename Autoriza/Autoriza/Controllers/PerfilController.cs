using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autoriza.DAO;
using Autoriza.Models;

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

    }
}