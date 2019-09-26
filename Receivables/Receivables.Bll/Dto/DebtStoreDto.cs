using System;

namespace Receivables.Bll.Dto
{
    public class DebtStoreDto
    {
        public int Id { get; set; }

        public int DebtPaidId { get; set; }

        public DateTime Date { get; set; }

        public int DebtStoreType { get; set; }

        public decimal Sum { get; set; }

        public string Number { get; set; }
    }
}
