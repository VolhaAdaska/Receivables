using System;

namespace Receivables.Bll.Dto
{
    public class StoreDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public int Number { get; set; }

        public int CurrencyCode { get; set; }

        public string Currency { get; set; }

        public int AgreementId { get; set; }
    }
}