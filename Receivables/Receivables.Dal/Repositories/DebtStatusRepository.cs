using Receivables.Dal.Context;
using Receivables.Dal.Interfaces;
using Receivables.Dal.Models;

namespace Receivables.Dal.Repositories
{
    public class DebtStatusRepository : BaseRepository<DebtStatus>, IDebtStatusRepository
    {
        public DebtStatusRepository(ReceivablesContext context)
        : base(context)
        {
        }
    }
}
