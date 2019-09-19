using System;
using System.Collections.Generic;

namespace Receivables.Dal.Models
{
    public class Agreement : BaseEntity
    {
        public string Name { get; set; }

        public int Number { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Postponement { get; set; }

        public virtual Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public bool IsClosed { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
