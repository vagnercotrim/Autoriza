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
        private readonly Autenticador _autenticador;

        public LoginController(SistemaDAO sistemaDao, Autenticador autenticador)
        {
            _sistemaDao = sistemaDao;
            this._autenticador = autenticador;
        }

        public ActionResult Login(String identificacao, String acesso, String urlRetorno)
        {
            Sistema sistema = _sistemaDao.FindByIdentificacaoEAcesso(identificacao, acesso);

            LoginView view = new LoginView { Sistema = sistema, UrlRetorno = urlRetorno };

            return View(view);
        }

        [HttpPost]
        public ActionResult Login(LoginView login)
        {
            login.Sistema = _sistemaDao.Get(login.Sistema.Id);

            if (_autenticador.Verifica(login.Usuario))
            {
                return Redirect(login.UrlRetorno);
            }

            return View(login);
        }

    }
}