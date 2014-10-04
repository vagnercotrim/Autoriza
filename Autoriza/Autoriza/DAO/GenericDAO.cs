using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace Autoriza.DAO
{
    public class GenericDAO<T> where T : class
    {

        private ISession Session;

        public GenericDAO(ISession session)
        {
            Session = session;
        }

        public T Get(int id)
        {
            return Session.Get<T>(id);
        }

    }
}