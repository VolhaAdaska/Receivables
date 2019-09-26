using System;

namespace Receivables.Bll.Dto
{
    public class DebtStatusDto
    {
        public int Id { get; set; }

        public int DebtId { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        public string Value { get; set; }
    }
}
