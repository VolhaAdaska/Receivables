namespace Receivables.Models
{
    public class DebtPaidModel
    {
        public int Id { get; set; }

        public int DebtId { get; set; }

        public decimal SumAmount { get; set; }

        public decimal Fine { get; set; }

        public decimal StateDuty { get; set; }

        public decimal Total { get; set; }
    }
}