namespace Receivables.Bll.Dto
{
    public class DebtPaidDto
    {
        public int Id { get; set; }

        public int DebtId { get; set; }

        public decimal Sum { get; set; }
    }
}
