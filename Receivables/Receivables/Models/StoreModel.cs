using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Receivables.Dal.Models;

namespace Receivables.Models
{
    public class StoreModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public int Number { get; set; }

        public string Currency { get; set; }

        public int AgreementId { get; set; }

        public IList<Product> Products { get; set; }
    }
}