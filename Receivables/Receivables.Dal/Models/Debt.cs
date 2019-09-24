using System;

namespace Receivables.Dal.Models
{
    public class Debt : BaseEntity
    {
        public decimal SumDebt { get; set; }

        public int AgreementId { get; set; }

        public int CustomerId { get; set; }

        public string Status { get; set; }

        public DateTime Date { get; set; }

        public int Number { get; set; }
    }
}