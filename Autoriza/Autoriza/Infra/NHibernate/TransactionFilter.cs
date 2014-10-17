using System.Web.Mvc;
using NHibernate;

namespace Autoriza.Infra.NHibernate
{
    public class TransactionFilter : IActionFilter
    {

        private readonly ISession _session;

        public TransactionFilter(ISession session)
        {
            _session = session;
        }
        
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _session.BeginTransaction();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (_session.Transaction.IsActive)
                _session.Transaction.Commit();
            else
                _session.Transaction.Rollback();
        }
    }
}