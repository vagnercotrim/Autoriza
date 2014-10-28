using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Fluentx.Mvc;

namespace Sistema.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            String url = String.Format("http://localhost:24657/login/login?identificacao={0}&acesso={1}&urlRetorno={2}", "autoriza_sso", "skE7VDhwUh6ERWN", "http://localhost:40964/");

            //return Redirect(url);

            if (Request["token"] == null)
            {
                Dictionary<string, object> postData = new Dictionary<string, object>();
                postData.Add("identificacao", "autoriza_sso");
                postData.Add("acesso", "h6BZy4E57VWiotl");
                postData.Add("urlRetorno", "http://localhost:40964/");

                return this.RedirectAndPost("http://localhost:24657/login/login", postData);
            }

            return View();
        }

    }
}