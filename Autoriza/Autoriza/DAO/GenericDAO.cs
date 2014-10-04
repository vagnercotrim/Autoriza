using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autoriza.Models;
using NHibernate;
using NHibernate.Linq;

namespace Autoriza.DAO
{
    public class GenericDAO<T> where T : class
    {

        private readonly ISession Session;

        public GenericDAO(ISession session)
        {
            Session = session;
        }

        public T Get(int id)
        {
            return Session.Get<T>(id);
        }

        public IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public void Save(T t)
        {
            Session.Save(t);
        }

        public void Update(T t)
        {
            Session.Update(t);
        }

        public void Delete(T t)
        {
            Session.Delete(t);
        }

        public void Refresh(T t)
        {
            Session.Refresh(t);
        }

    }
}