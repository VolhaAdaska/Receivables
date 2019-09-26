namespace Receivables.Dal.Models
{
    public class DebtPaid : BaseEntity
    {
        public virtual Debt Debt { get; set; }

        public int DebtPaidId { get; set; }

        public decimal SumAmount { get; set; }

        public decimal Penalties { get; set; }

        public decimal InterestAmount { get; set; }

        public decimal Fine { get; set; }

        public decimal StateDuty { get; set; }
    }
}
