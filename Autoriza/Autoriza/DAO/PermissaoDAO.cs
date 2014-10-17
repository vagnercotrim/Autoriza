using System.Collections.Generic;
using Autoriza.Models;
using NHibernate;
using NHibernate.Criterion;

namespace Autoriza.DAO
{
    public class PermissaoDAO
    {

        private readonly GenericDAO<Permissao> _dao;
        private readonly ISession _session;

        public PermissaoDAO(ISession session)
        {
            _dao = new GenericDAO<Permissao>(session);
            _session = session;
        }

        public Permissao Get(int id)
        {
            return _dao.Get(id);
        }

        public void Save(Permissao permissao)
        {
            _dao.Save(permissao);
        }


        public void Update(Permissao permissao)
        {
            _dao.Update(permissao);
        }
        
        public IList<Permissao> GetAllBySistema(int id)
        {
            ICriteria criteria = _session.CreateCriteria<Permissao>()
                                        .Add(Restrictions.Eq("Sistema.Id", id));

            return criteria.List<Permissao>();
        }

        public Permissao FindByNome(int idSistema, string nome)
        {
            ICriteria criteria = _session.CreateCriteria<Permissao>()
                                        .Add(Restrictions.Eq("Sistema.Id", idSistema))
                                        .Add(Restrictions.Eq("Nome", nome));
            
            return criteria.UniqueResult<Permissao>();
        }

    }
}