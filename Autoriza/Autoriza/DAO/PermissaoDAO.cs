﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autoriza.Models;
using NHibernate;
using NHibernate.Criterion;

namespace Autoriza.DAO
{
    public class PermissaoDAO
    {

        private readonly GenericDAO<Permissao> dao;
        private readonly ISession session;

        public PermissaoDAO(ISession session)
        {
            dao = new GenericDAO<Permissao>(session);
            this.session = session;
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
        
        public IList<Permissao> GetAllBySistema(int id)
        {
            ICriteria criteria = session.CreateCriteria<Permissao>().Add(Expression.Eq("Sistema.Id", id));

            return criteria.List<Permissao>();
        }
    }
}