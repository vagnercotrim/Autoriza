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

        private readonly GenericDAO<Sistema> _dao;
        private readonly ISession _session;

        public SistemaDAO(ISession session)
        {
            _dao = new GenericDAO<Sistema>(session);
            _session = session;
        }

        public Sistema Get(int id)
        {
            return _dao.Get(id);
        }

        public IList<Sistema> GetAll()
        {
            return _dao.GetAll().ToList();
        }

        public void Save(Sistema sistema)
        {
            _dao.Save(sistema);
        }


        public void Update(Sistema sistema)
        {
            _dao.Update(sistema);
        }

        public Sistema FindByNome(String nome)
        {
            ICriteria criteria = _session.CreateCriteria<Sistema>()
                                        .Add(Restrictions.Eq("Nome", nome));

            return criteria.UniqueResult<Sistema>();
        }

        public Sistema FindByChaveIdentificacao(String chave)
        {
            ICriteria criteria = _session.CreateCriteria<Sistema>()
                                        .Add(Restrictions.Eq("ChaveIdentificacao", chave));

            return criteria.UniqueResult<Sistema>();
        }
        
    }
}