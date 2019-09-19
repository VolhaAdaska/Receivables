using System;

namespace Receivables.Dal.Models
{
    public class Account : BaseEntity
    {
        public int? StoreId { get; set; }

        public int? ProductId { get; set; }

        public int? Number { get; set; }

        public decimal Sum { get; set; }

        public DateTime Date { get; set; }
    }
}
