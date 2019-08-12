using System;

namespace Receivables.Dal.Models
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public int Number { get; set; }

        public decimal Sum { get; set; }

        public Contract Contract { get; set; }

        public int ContractId { get; set; }
    }
}