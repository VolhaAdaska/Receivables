using System;
using System.Collections.Generic;

namespace Receivables.Models
{
    public class DebtModel
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string CustomerINN { get; set; }

        public string AgreementName { get; set; }

        public int Postponement { get; set; }

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

        public decimal Total { get; set; }

        public decimal TotalExacted { get; set; }

        public string NumDoc { get; set; }

        public DateTime DateDoc { get; set; }

        public DebtPaidModel DebtPaid { get; set; }

        public IList<DebtStatusModel> DebtStatuses { get; set; }

        public IList<DebtStore> DebtStores { get; set; }

        public DebtClaim DebtClaim { get; set; }
    }
}