﻿using System;

namespace Receivables.Dal.Models
{
    public class Account : BaseEntity
    {
        public int CustomerId { get; set; }

        public int AgreementId { get; set; }

        public string CustomerName { get; set; }

        public string AgreementName { get; set; }

        public string StoreName { get; set; }

        public string ProductName { get; set; }

        public int? StoreId { get; set; }

        public int? ProductId { get; set; }

        public int? Number { get; set; }

        public decimal Sum { get; set; }

        public DateTime Date { get; set; }
    }
}
