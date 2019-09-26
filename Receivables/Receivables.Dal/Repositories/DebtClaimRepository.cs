using Receivables.Dal.Context;
using Receivables.Dal.Interfaces;
using Receivables.Dal.Models;

namespace Receivables.Dal.Repositories
{
    public class DebtClaimRepository : BaseRepository<DebtClaim>, IDebtClaimRepository
    {
        public DebtClaimRepository(ReceivablesContext context)
         : base(context)
        {
        }
    }
}
