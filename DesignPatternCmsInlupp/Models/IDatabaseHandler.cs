using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternCmsInlupp.Models
{
    interface IDatabaseHandler
    {
        string CustomerDB();
        string InvoicesDB();
        string LoansDB();
        string PaymentsDB();

    }
}
