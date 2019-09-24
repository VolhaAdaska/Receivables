using System;

namespace Receivables.Models
{
    public class DebtModel
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string CustomerINN { get; set; }

        public string AgreementName { get; set; }

        public int Postponement { get; set; }

        public string Status { get; set; }

        public DateTime Date { get; set; }

        public int Number { get; set; }

        public decimal SumAmount { get; set; }

        public decimal Penalties { get; set; }

        public decimal InterestAmount { get; set; }

        public decimal Fine { get; set; }

        public decimal StateDuty { get; set; }

        public decimal SumExacted { get; set; }

        public decimal PenaltiesExacted { get; set; }

        public decimal InterestAmountExacted { get; set; }

        public decimal FineExacted { get; set; }

        public decimal StateDutyExacted { get; set; }
    }
}