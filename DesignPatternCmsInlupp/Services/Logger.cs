using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatternCmsInlupp.Services
{
    public class Logger
    {
        private Logger()
        {

        }
        public enum Actions{
            CallReceived,
            ViewCustomerPage,
            ListCustomersPage,
            ParametrarPage,
            CreatingCustomer,
            CreatingLoan

        };
        private static Logger _theOnlyLogg = null;
        public void LogAction(Actions action, string message)
        {
            System.IO.File.AppendAllText(HttpContext.Current.Server.MapPath("~/log.txt"),  $"{action.ToString()} - {DateTime.Now.ToString("yyyy-MM-dd HH:mm:SS")}  {message}\n");
        }
        public static Logger GetInstance()
        {
            if (_theOnlyLogg == null)
            {
                _theOnlyLogg = new Logger();
            }
            return _theOnlyLogg;
        }

    }
}