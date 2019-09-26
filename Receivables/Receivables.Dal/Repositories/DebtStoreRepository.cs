using Receivables.Dal.Context;
using Receivables.Dal.Interfaces;
using Receivables.Dal.Models;

namespace Receivables.Dal.Repositories
{
    public class DebtStoreRepository : BaseRepository<DebtStore>, IDebtStoreRepository
    {
        public DebtStoreRepository(ReceivablesContext context)
            : base(context)
        {
        }
    }
}
