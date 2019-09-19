using System;
using System.Collections.Generic;

namespace Receivables.Dal.Models
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }

        public int Number { get; set; }

        public int CurrencyCode { get; set; }

        public virtual Agreement Agreement { get; set; }

        public int AgreementId { get; set; }
    }
}