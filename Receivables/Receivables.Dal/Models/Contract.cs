using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace Receivables.Dal.Models
{
    public class Contract : BaseEntity
    {
        public string Name { get; set; }

        public int Number { get; set; }

        public DateTime Date { get; set; }

        public int Postponement { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
