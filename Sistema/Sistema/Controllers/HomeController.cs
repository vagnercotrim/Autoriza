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
            RestClient client = new RestClient(@"http://localhost:24657");

            IRestRequest request = Post(@"login/login").AddParameter("identificacao", "autoriza_sso")
                                                       .AddParameter("acesso", "sksn48ndj")
                                                       .AddParameter("urlRetorno", "http://localhost:40964/");

            var response = client.Execute<Usuario>(request);
            Usuario user = response.Data;

            return View();
        }

        private IRestRequest Post(String recurso)
        {
            IRestRequest request = new RestRequest(recurso, Method.POST);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            return request;
        }

    }
}