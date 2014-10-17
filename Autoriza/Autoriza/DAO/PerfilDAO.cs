using Autoriza.Models;
using NHibernate;
using NHibernate.Criterion;

namespace Autoriza.DAO
{
    public class PerfilDAO
    {

        private readonly GenericDAO<Perfil> _dao;
        private readonly ISession _session;

        public PerfilDAO(ISession session)
        {
            _dao = new GenericDAO<Perfil>(session);
            _session = session;
        }

        public Perfil Get(int id)
        {
            return _dao.Get(id);
        }

        public void Save(Perfil perfil)
        {
            _dao.Save(perfil);
        }


        public void Update(Perfil perfil)
        {
            _dao.Update(perfil);
        }

        public Perfil FindByNome(int idSistema, string nome)
        {
            ICriteria criteria = _session.CreateCriteria<Perfil>()
                                        .Add(Restrictions.Eq("Sistema.Id", idSistema))
                                        .Add(Restrictions.Eq("Nome", nome));

            return criteria.UniqueResult<Perfil>();
        }
    }
}