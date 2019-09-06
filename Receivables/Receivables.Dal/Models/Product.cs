﻿namespace Receivables.Dal.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public int Code { get; set; }

        public virtual Store Store { get; set; }

        public int StoreId { get; set; }
    }
}
