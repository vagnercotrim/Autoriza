using System.Web.Mvc;
using NHibernate;

namespace Autoriza.Infra.NHibernate
{
    public class TransactionFilter : IActionFilter
    {

        private ISession session;

        public TransactionFilter(ISession session)
        {
            this.session = session;
        }
        
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            session.BeginTransaction();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (session.Transaction.IsActive)
                session.Transaction.Commit();
            else
                session.Transaction.Rollback();
        }
    }
}