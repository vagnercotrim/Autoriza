using System;
using System.Collections.Generic;
using System.Linq;
using Autoriza.Models;
using NHibernate;
using NHibernate.Criterion;

namespace Autoriza.DAO
{
    public class SistemaDAO
    {

        private readonly GenericDAO<Sistema> dao;
        private readonly ISession session;

        public SistemaDAO(ISession session)
        {
            dao = new GenericDAO<Sistema>(session);
            this.session = session;
        }

        public Sistema Get(int id)
        {
            return dao.Get(id);
        }

        public IList<Sistema> GetAll()
        {
            return dao.GetAll().ToList();
        }

        public void Save(Sistema sistema)
        {
            dao.Save(sistema);
        }


        public void Update(Sistema sistema)
        {
            dao.Update(sistema);
        }

        public Sistema FindByNome(String nome)
        {
            ICriteria criteria = session.CreateCriteria<Sistema>()
                                        .Add(Expression.Eq("Nome", nome));

            return criteria.UniqueResult<Sistema>();
        }

    }
}