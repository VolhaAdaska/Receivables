using System;

namespace Receivables.Dal.Models
{
    public class DebtStore : BaseEntity
    {
        public virtual Debt Debt { get; set; }

        public int DebtId { get; set; }

        public DateTime Date { get; set; }

        public int DebtStoreType { get; set; }

        public decimal Sum { get; set; }

        public string Number { get; set; }
    }
}
