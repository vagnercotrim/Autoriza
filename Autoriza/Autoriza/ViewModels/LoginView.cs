using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autoriza.Models;

namespace Autoriza.ViewModels
{
    public class LoginView
    {

        public Sistema Sistema { get; set; }

        public Usuario Usuario { get; set; }

        public String UrlRetorno { get; set; }

    }
}