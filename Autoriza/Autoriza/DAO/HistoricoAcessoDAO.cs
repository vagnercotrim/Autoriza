using Autoriza.Models;
using NHibernate;
using NHibernate.Criterion;

namespace Autoriza.DAO
{
    public class HistoricoAcessoDAO
    {
        
        private readonly GenericDAO<HistoricoAcesso> _dao;
        private readonly ISession _session;

        public HistoricoAcessoDAO(ISession session)
        {
            _dao = new GenericDAO<HistoricoAcesso>(session);
            _session = session;
        }

        public void Save(HistoricoAcesso acesso)
        {
            _dao.Save(acesso);
        }

        public HistoricoAcesso FindByNome(int idSistema)
        {
            ICriteria criteria = _session.CreateCriteria<Perfil>()
                                         .Add(Restrictions.Eq("Sistema.Id", idSistema));

            return criteria.UniqueResult<HistoricoAcesso>();
        }

    }
}