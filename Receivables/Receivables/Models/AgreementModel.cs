using System;
using System.Collections.Generic;

namespace Receivables.Models
{
    public class AgreementModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Postponement { get; set; }

        public bool IsClosed { get; set; }

        public int CustomerId { get; set; }
    }
}