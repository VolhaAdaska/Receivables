namespace Receivables.Bll.Dto
{
    public class DebtDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerINN { get; set; }

        public int SumDebt { get; set; }

        public string Status { get; set; }
    }
}
