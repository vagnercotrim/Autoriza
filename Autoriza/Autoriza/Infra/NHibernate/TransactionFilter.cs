using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using NHibernate;

namespace Autoriza.Infra.NHibernate
{
    public class TransactionFilter : IActionFilter
    {

        private ISession Session;
        private ITransaction Transaction;

        public TransactionFilter(ISession session)
        {
            Session = session;
            Transaction = Session.Transaction;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Transaction.Begin();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(Transaction.IsActive)
                Transaction.Commit();
            else
                Transaction.Rollback();
        }

    }
}