using System;
using System.Collections.Generic;

namespace Receivables.Bll.Dto
{
    public class AgreementDto
    {
        public string Name { get; set; }

        public int Number { get; set; }

        public DateTime Date { get; set; }

        public int Postponement { get; set; }

        public CustomerDto Customer { get; set; }

        public int CustomerId { get; set; }

        public virtual IEnumerable<StoreDto> Stores { get; set; }
    }
}
