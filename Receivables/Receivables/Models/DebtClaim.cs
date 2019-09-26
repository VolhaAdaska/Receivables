using System;

namespace Receivables.Models
{
    public class DebtClaim
    {
        public int Id { get; set; }

        public int DebtId { get; set; }

        public int ClaimType { get; set; }

        public DateTime DateClaimStart { get; set; }

        public DateTime DateClaimEnd { get; set; }

        public string NumberClaim { get; set; }

        public double PenaltyRate { get; set; }

        public double RefinancingRate { get; set; }
    }
}