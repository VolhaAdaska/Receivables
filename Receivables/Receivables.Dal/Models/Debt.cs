namespace Receivables.Dal.Models
{
    public class Debt : BaseEntity
    {
        public decimal SumDebt { get; set; }

        public virtual Agreement Agreement { get; set; }

        public int AgreementId { get; set; }

        public int CustmerId { get; set; }

        public string Status { get; set; }
    }
}