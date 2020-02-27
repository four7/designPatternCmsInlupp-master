using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatternCmsInlupp.Services
{
    public class CachedInterestService : IInterestService
    {
        DateTime lastFetched;
        public CachedInterestService(IInterestService NextRate)
        {
            this.NextRate = NextRate;
        }

        private readonly IInterestService NextRate;
        static decimal interest;
        public decimal GetRiksbankensBaseRate()
        {
            if (interest == 0.0m || lastFetched > lastFetched.AddHours(24))
            {
                lastFetched = DateTime.Now;
                interest = NextRate.GetRiksbankensBaseRate();
            }
            return interest;
        }

    }
}