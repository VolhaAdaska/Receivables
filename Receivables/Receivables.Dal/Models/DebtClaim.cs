using System;

namespace Receivables.Dal.Models
{
    public class DebtClaim : BaseEntity
    {
        public virtual Debt Debt { get; set; }

        public int DebtId { get; set; }

        public int ClaimType { get; set; }

        public DateTime DateClaimStart { get; set; }

        public DateTime DateClaimEnd { get; set; }

        public string NumberClaim { get; set; }

        public double PenaltyRate { get; set; }

        public double RefinancingRate { get; set; }
    }
}
