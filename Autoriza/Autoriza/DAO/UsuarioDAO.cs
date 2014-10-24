using System;
using System.Collections.Generic;
using System.Linq;
using Autoriza.Models;
using NHibernate;
using NHibernate.Criterion;

namespace Autoriza.DAO
{
    public class UsuarioDAO
    {
        
        private readonly GenericDAO<Usuario> _dao;
        private readonly ISession _session;

        public UsuarioDAO(ISession session)
        {
            _dao = new GenericDAO<Usuario>(session);
            _session = session;
        }
        
        public Usuario Get(int id)
        {
            return _dao.Get(id);
        }

        public IList<Usuario> GetAll()
        {
            return _dao.GetAll().ToList();
        }

        public void Save(Usuario usuario)
        {
            _dao.Save(usuario);
        }


        public void Update(Usuario usuario)
        {
            _dao.Update(usuario);
        }

        public Usuario FindByNome(String nome)
        {
            ICriteria criteria = _session.CreateCriteria<Usuario>()
                                        .Add(Restrictions.Eq("Nome", nome));

            return criteria.UniqueResult<Usuario>();
        }

        public Usuario FindByLogin(String login)
        {
            ICriteria criteria = _session.CreateCriteria<Usuario>()
                                        .Add(Restrictions.Eq("Login", login));

            return criteria.UniqueResult<Usuario>();
        }

        public Usuario FindByEmail(String email)
        {
            ICriteria criteria = _session.CreateCriteria<Usuario>()
                                        .Add(Restrictions.Eq("Email", email));

            return criteria.UniqueResult<Usuario>();
        }

        public Usuario FindByLoginESenha(Usuario usuario)
        {
            ICriteria criteria = _session.CreateCriteria<Usuario>()
                                        .Add(Restrictions.Eq("Login", usuario.Login))
                                        .Add(Restrictions.Eq("Senha", usuario.Senha));

            return criteria.UniqueResult<Usuario>();
        }

    }
}