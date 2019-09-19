using System;

namespace Receivables.Models
{
    public class CalculationModel
    {
        public string CustomerName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? CustomerId { get; set; }
    }
}