using System;
using System.Collections.Generic;

namespace Receivables.Models
{
    public class AgreementModel
    {
        public string Name { get; set; }

        public int Number { get; set; }

        public DateTime Date { get; set; }

        public int Postponement { get; set; }

        public CustomerModel Customer { get; set; }

        public int CustomerId { get; set; }

        public virtual IEnumerable<StoreModel> Stores { get; set; }
    }
}