using System;
using System.Web.Mvc;
using RestSharp;
using Sistema.Models;

namespace Sistema.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            String url = String.Format("http://localhost:24657/login/login?identificacao={0}&acesso={1}&urlRetorno={2}", "autoriza_sso", "skE7VDhwUh6ERWN", "http://localhost:40964/");

            return Redirect(url);
        }

    }
}