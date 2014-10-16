using System;
using System.Web.Mvc;

namespace Autoriza.Infra.NHibernate
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TransactionAttribute : FilterAttribute
    {
    }
}