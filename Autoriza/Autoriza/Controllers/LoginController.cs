using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autoriza.Controllers
{
    public class LoginController : Controller
    {


        [HttpPost]
        public ActionResult Login(String identificacao, String acesso, String urlRetorno)
        {
            return Json(new {Nome = "nome", Email = "email"}, JsonRequestBehavior.AllowGet);
        }

    }
}