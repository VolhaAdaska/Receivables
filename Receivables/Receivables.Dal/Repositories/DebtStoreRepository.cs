using System.Collections.Generic;
using System.Linq;
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

        public IList<DebtStore> GetByDebtId(int id)
        {
            return entities.Where(x => x.DebtId == id).ToList();
        }
    }
}
