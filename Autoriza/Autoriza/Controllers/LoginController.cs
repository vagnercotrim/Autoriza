using System;
using System.Web.Mvc;
using Autoriza.Models;

namespace Autoriza.Controllers
{
    public class LoginController : Controller
    {
        
        public ActionResult Login(String identificacao, String acesso, String urlRetorno)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            return View(usuario);
        }

    }
}