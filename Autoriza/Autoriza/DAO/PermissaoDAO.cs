using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autoriza.Models;
using NHibernate;

namespace Autoriza.DAO
{
    public class PermissaoDAO
    {

        private readonly GenericDAO<Permissao> dao;

        public PermissaoDAO(ISession session)
        {
            dao = new GenericDAO<Permissao>(session);
        }

        public Permissao Get(int id)
        {
            return dao.Get(id);
        }

        public void Save(Permissao permissao)
        {
            dao.Save(permissao);
        }


        public void Update(Permissao permissao)
        {
            dao.Update(permissao);
        }

    }
}