using System;

namespace Receivables.Dal.Models
{
    public class DebtStatus : BaseEntity
    {
        public virtual Debt Debt { get; set; }

        public int DebtId { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        public string Value { get; set; }
    }
}
