using Autoriza.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autoriza.DAO
{
    public class PerfilDAO
    {

        private readonly GenericDAO<Perfil> dao;

        public PerfilDAO(ISession session)
        {
            dao = new GenericDAO<Perfil>(session);
        }

        public Perfil Get(int id)
        {
            return dao.Get(id);
        }

        public void Save(Perfil perfil)
        {
            dao.Save(perfil);
        }


        public void Update(Perfil perfil)
        {
            dao.Update(perfil);
        }

    }
}