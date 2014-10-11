using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autoriza.DAO;
using Autoriza.Models;

namespace Autoriza.Jobs
{
    public class VerificaSistemaOnline
    {
        private SistemaDAO sistemaDao;

        public VerificaSistemaOnline(SistemaDAO sistemaDAO)
        {
            sistemaDao = sistemaDAO;
        }

        public void Verifica()
        {
            sistemaDao.Save(new Sistema() {Nome = "asd", ChaveAcesso = DateTime.Now.ToString(), Url = "url"});
        }

    }
}