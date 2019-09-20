using System;
using System.Collections.Generic;

namespace Receivables.Models
{
    public class CalculationModel
    {
        public string CustomerName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? CustomerId { get; set; }

        public IList<AccountModel> Accounts { get; set; }

        public IList<SearchModel> Customers { get; set; }
    }
}