﻿using System;

namespace Receivables.Bll.Dto
{
    public class DebtDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int AgreementId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerINN { get; set; }

        public string Status { get; set; }

        public DateTime Date { get; set; }

        public int Number { get; set; }

        public decimal SumAmount { get; set; }

        public decimal Penalties { get; set; }

        public decimal InterestAmount { get; set; }

        public decimal Fine { get; set; }

        public decimal StateDuty { get; set; }

        public decimal SumExacted { get; set; }

        public decimal PenaltiesExacted { get; set; }

        public decimal InterestAmountExacted { get; set; }

        public decimal FineExacted { get; set; }

        public decimal StateDutyExacted { get; set; }

        public string Currency { get; set; }

        public string NumDoc { get; set; }

        public DateTime DateDoc { get; set; }
    }
}
