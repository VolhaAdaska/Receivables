namespace Receivables.Bll.Dto
{
    public class DebtPaidDto
    {
        public int Id { get; set; }

        public int DebtPaidId { get; set; }

        public decimal SumAmount { get; set; }

        public decimal Penalties { get; set; }

        public decimal InterestAmount { get; set; }

        public decimal Fine { get; set; }

        public decimal StateDuty { get; set; }
    }
}
