namespace Receivables.Dal.Models
{
    public class Debt : BaseEntity
    {
        public decimal Sum { get; set; }
        public virtual Agreement Agreement { get; set; }
    }
}