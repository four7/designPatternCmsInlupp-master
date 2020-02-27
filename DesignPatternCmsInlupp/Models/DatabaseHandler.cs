using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatternCmsInlupp.Models
{
    public class DatabaseHandler : IDatabaseHandler
    {
        public string CustomerDB()
        {
           var databas = HttpContext.Current.Server.MapPath("~/customers.txt");
            return databas;
        }

        public string InvoicesDB()
        {
            var databas = HttpContext.Current.Server.MapPath("~/invoices.txt");
            return databas;
        }

        public string LoansDB()
        {
            var databas = HttpContext.Current.Server.MapPath("~/loans.txt");
            return databas;
        }

        public string PaymentsDB()
        {
            var databas = HttpContext.Current.Server.MapPath("~/payments.txt");
            return databas;
        }
    }
}