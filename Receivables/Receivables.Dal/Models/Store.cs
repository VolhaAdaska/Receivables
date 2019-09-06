using System;
using System.Collections.Generic;

namespace Receivables.Dal.Models
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public int Number { get; set; }

        public decimal Sum { get; set; }

        public virtual Agreement Agreement { get; set; }

        public int AgreementId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}