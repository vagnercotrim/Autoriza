using Autoriza.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Criterion;

namespace Autoriza.DAO
{
    public class PerfilDAO
    {

        private readonly GenericDAO<Perfil> dao;
        private readonly ISession session;

        public PerfilDAO(ISession session)
        {
            dao = new GenericDAO<Perfil>(session);
            this.session = session;
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

        public Perfil FindByNome(int idSistema, string nome)
        {
            ICriteria criteria = session.CreateCriteria<Perfil>().Add(Expression.Eq("Sistema.Id", idSistema)).Add(Expression.Eq("Nome", nome));

            return criteria.UniqueResult<Perfil>();
        }
    }
}