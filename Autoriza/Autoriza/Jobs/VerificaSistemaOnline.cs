using System;
using System.Globalization;
using Autoriza.DAO;
using Autoriza.Models;

namespace Autoriza.Jobs
{
    public class VerificaSistemaOnline
    {
        private readonly SistemaDAO _sistemaDao;

        public VerificaSistemaOnline(SistemaDAO sistemaDao)
        {
            _sistemaDao = sistemaDao;
        }

        public void Verifica()
        {
            _sistemaDao.Save(new Sistema {Nome = "asd", ChaveAcesso = DateTime.Now.ToString(CultureInfo.InvariantCulture), Url = "url"});
        }

    }
}