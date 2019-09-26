using System.Collections.Generic;
using System.Linq;
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

        public IList<DebtStatus> GetByDebtId(int id)
        {
            return entities.Where(x => x.DebtId == id).ToList();
        }
    }
}
