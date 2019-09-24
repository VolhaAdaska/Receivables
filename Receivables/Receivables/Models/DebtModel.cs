namespace Receivables.Models
{
    public class DebtModel
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string CustomerINN { get; set; }

        public string AgreementName { get; set; }

        public int Postponement { get; set; }

        public decimal SumDebt { get; set; }

        public string Status { get; set; }
    }
}