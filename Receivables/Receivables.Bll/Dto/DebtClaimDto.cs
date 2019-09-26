using System;

namespace Receivables.Bll.Dto
{
    public class DebtClaimDto
    {
        public int Id { get; set; }

        public int DebtPaidId { get; set; }

        public int ClaimType { get; set; }

        public DateTime DateClaimStart { get; set; }

        public DateTime DateClaimEnd { get; set; }

        public string NumberClaim { get; set; }

        public double PenaltyRate { get; set; }

        public double RefinancingRate { get; set; }
    }
}
