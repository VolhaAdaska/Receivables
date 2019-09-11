namespace Receivables.Models
{
    public class DebtModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerINN { get; set; }

        public int SumDebt { get; set; }
    }
}