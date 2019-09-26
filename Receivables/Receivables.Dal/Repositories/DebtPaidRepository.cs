using Receivables.Dal.Context;
using Receivables.Dal.Interfaces;
using Receivables.Dal.Models;

namespace Receivables.Dal.Repositories
{
    public class DebtPaidRepository : BaseRepository<DebtPaid>, IDebtPaidRepository
    {
        public DebtPaidRepository(ReceivablesContext context)
        : base(context)
        {
        }
    }
}
