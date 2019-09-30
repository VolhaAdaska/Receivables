namespace Receivables.Dal.Models
{
    public class DebtPaid : BaseEntity
    {
        public virtual Debt Debt { get; set; }

        public int DebtId { get; set; }

        public decimal Sum { get; set; }
    }
}
