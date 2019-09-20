using System;

namespace Receivables.Bll.Dto
{
    public class AccountDto
    {
        public int AgreementId { get; set; }

        public string AgreementName { get; set; }

        public string StoreName { get; set; }

        public string ProductName { get; set; }

        public int? Number { get; set; }

        public decimal Sum { get; set; }

        public DateTime Date { get; set; }
    }
}
