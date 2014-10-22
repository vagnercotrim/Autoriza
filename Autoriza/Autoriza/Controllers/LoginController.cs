using System;
using System.Web.Mvc;
using Autoriza.DAO;
using Autoriza.Domain;
using Autoriza.Models;
using Autoriza.ViewModels;

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

            LoginView view = new LoginView() { Sistema = sistema };

            return View(view);
        }

        [HttpPost]
        public ActionResult Login(LoginView login)
        {
            login.Sistema = _sistemaDao.Get(login.Sistema.Id);

            Autenticador aut = new Autenticador(login.Usuario);

            return View(login);
        }

    }
}