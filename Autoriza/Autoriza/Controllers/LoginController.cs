using System;
using System.Web.Mvc;
using Autoriza.DAO;
using Autoriza.Models;

namespace Autoriza.Controllers
{
    public class LoginController : Controller
    {

        private readonly SistemaDAO _sistemaDao;

        public LoginController(SistemaDAO sistemaDao)
        {
            _sistemaDao = sistemaDao;
        }

        public ActionResult Login(String identificacao, String acesso, String urlRetorno)
        {
            Sistema sistema = _sistemaDao.FindByIdentificacaoEAcesso(identificacao, acesso);

            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            return View(usuario);
        }

    }
}