using DesignPatternCmsInlupp.Models;
using DesignPatternCmsInlupp.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignPatternCmsInlupp.Models
{
    public class Customer
    {
        public Customer()
        {
            Loans = new List<Loan>();
        }
        public string PersonNummer { get; set; }
        public List<Loan> Loans { get; set; }

        public int Total()
        {
            return Loans.Sum(l => l.Belopp);
        }

        public bool HasEverBeenLatePaying { get {
                foreach (var loan in Loans)
                    foreach (var i in loan.Invoices)
                        if (i.LatePayment() > 0) return true;
                return false;
            } }
        //public Customer FindCustomers(string personnummer)
        //{
        //    Customer customer = null;
        //    string databas = HttpContext.Current.Server.MapPath("~/customers.txt");
        //    foreach (var line in System.IO.File.ReadAllLines(databas))
        //    {
        //        string[] parts = line.Split(';');
        //        if (parts.Length < 1) continue;
        //        if (parts[0] == personnummer)
        //            if (customer == null)
        //                customer = new Customer { PersonNummer = personnummer };
        //    }
        //    if (customer == null) return null;
        //    SetLoansForCustomer(customer);
        //    SetInvoicesForCustomer(customer);
        //    SetPaymentsForCustomer(customer);
        //    return customer;
        //}
        //public void SetLoansForCustomer(Customer c)
        //{
        //    string databas = HttpContext.Current.Server.MapPath("~/loans.txt");
        //    foreach (var line in System.IO.File.ReadAllLines(databas))
        //    {
        //        string[] parts = line.Split(';');
        //        if (parts.Length < 2) continue;
        //        if (parts[0] == c.PersonNummer)
        //        {
        //            var loan = new Loan
        //            {
        //                LoanNo = parts[1],
        //                Belopp = Convert.ToInt32(parts[2]),
        //                FromWhen = DateTime.ParseExact(parts[3], "yyyy-MM-dd", CultureInfo.InvariantCulture),
        //                InterestRate = Convert.ToDecimal(parts[4])
        //            };

        //            c.Loans.Add(loan);
        //        }
        //    }

        //}

        //public void SetInvoicesForCustomer(Customer customer)
        //{
        //    string databas = HttpContext.Current.Server.MapPath("~/invoices.txt");
        //    foreach (var line in System.IO.File.ReadAllLines(databas))
        //    {
        //        string[] parts = line.Split(';');
        //        if (parts.Length < 2) continue;
        //        var loan = customer.Loans.FirstOrDefault(r => r.LoanNo == parts[0]);
        //        if (loan == null) continue;
        //        var invoice = new Invoice
        //        {
        //            InvoiceNo = Convert.ToInt32(parts[1]),
        //            Belopp = Convert.ToInt32(parts[2]),
        //            InvoiceDate = DateTime.ParseExact(parts[3], "yyyy-MM-dd", CultureInfo.InvariantCulture),
        //            DueDate = DateTime.ParseExact(parts[3], "yyyy-MM-dd", CultureInfo.InvariantCulture),
        //        };
        //        loan.Invoices.Add(invoice);
        //    }


        //}

        public void SetPaymentsForCustomer(Customer customer)
        {
            string databas = HttpContext.Current.Server.MapPath("~/payments.txt");
            foreach (var line in System.IO.File.ReadAllLines(databas))
            {
                string[] parts = line.Split(';');
                if (parts.Length < 2) continue;
                var invoice = customer.Loans.SelectMany(r => r.Invoices).FirstOrDefault(i => i.InvoiceNo == Convert.ToInt32(parts[0]));
                if (invoice == null) continue;
                var payment = new Payment
                {
                    Belopp = Convert.ToInt32(parts[1]),
                    PaymentDate = DateTime.ParseExact(parts[2], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    BankPaymentReference = parts[3],
                };
                invoice.Payments.Add(payment);
            }


        }

    }
}