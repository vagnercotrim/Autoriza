using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autoriza.Models;
using NHibernate;

namespace Autoriza.DAO
{
    public class SistemaDAO
    {

        private readonly GenericDAO<Sistema> dao; 

        public SistemaDAO(ISession session)
        {
            dao = new GenericDAO<Sistema>(session);
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

    }
}