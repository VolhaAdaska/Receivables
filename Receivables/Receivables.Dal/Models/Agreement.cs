using System;

namespace Receivables.Dal.Models
{
    public class Agreement : BaseEntity
    {
        public string Name { get; set; }

        public int Number { get; set; }

        public DateTime Date { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
