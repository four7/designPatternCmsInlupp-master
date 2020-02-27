using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatternCmsInlupp.FinansInspektionsRapportering
{
    public class FinanceReport
    {
        public enum ReportType
        {
            Loan,
            LatePayment,
            AverageRta
        }
        public ReportType Type { get; set; }
        public decimal LoanBelopp { get; }
        public string PersonNummer { get; set; }
        public string LoanNumber { get; set; }
        public decimal AvgRta { get; set; }
        public decimal LatePaymentBelopp { get; set; }

        //private readonly Report.ReportType Type;
        //private readonly string PersonNummer;
        //private readonly string LoanNumber;
        //private readonly decimal AvgRta;
        //private readonly decimal LoanBelopp;
        //private readonly decimal LatePaymentBelopp;

        public void Send()
        {
            string transaction = "";
            if (Type == FinanceReport.ReportType.AverageRta)
            {
                transaction = $"AR;{AvgRta}";
            }
            if (Type == FinanceReport.ReportType.LatePayment)
            {
                transaction = $"AR;{PersonNummer};{LoanNumber};{LatePaymentBelopp}";
            }
            if (Type == FinanceReport.ReportType.Loan)
            {
                transaction = $"AR;{PersonNummer};{LoanNumber};{LoanBelopp}";
            }
            //Send transaction
            //Dummy --- nothing happens here...
        }

        public FinanceReport(FinanceReport.ReportType type, string personNummer, string loanNumber, decimal avgRta, decimal loanBelopp, decimal latePaymentBelopp)
        {
            
            
            this.Type = type;
            this.PersonNummer = personNummer;
            this.AvgRta = avgRta;
            this.LoanNumber = loanNumber;
            this.LoanBelopp = loanBelopp;
            this.LatePaymentBelopp = latePaymentBelopp;
        }
    }
    public class FinanceReportBuilder
    {
        private FinanceReport.ReportType Type;
        private string PersonNummer;
        private string LoanNumber;
        private decimal AvgRta;
        private decimal LoanBelopp;
        private decimal LatePaymentBelopp;

        public FinanceReportBuilder WithType(FinanceReport.ReportType Type)
        {
            this.Type = Type;
            return this;
        }
        public FinanceReportBuilder WithPersonNr(string personNummer)
        {
            this.PersonNummer = personNummer;
            return this;
        }
        public FinanceReportBuilder WithLoanNr(string loanNumber)
        {
            this.LoanNumber = loanNumber;
            return this;
        }
        public FinanceReportBuilder WithRnta(decimal avgRta)
        {
            this.AvgRta = avgRta;
            return this;
        }
        public FinanceReportBuilder WithLoanBelopp(decimal loanBelopp)
        {
            this.LoanBelopp = loanBelopp;
            return this;
        }
        public FinanceReportBuilder WithLatePay(decimal latePaymentBelopp)
        {
            this.LatePaymentBelopp = latePaymentBelopp;
            return this;
        }
        public FinanceReport Build()
        {
            var Report = new FinanceReport(this.Type, this.PersonNummer, this.LoanNumber, this.AvgRta, this.LoanBelopp, this.LatePaymentBelopp);
                return Report;
        }
        

    }
}
