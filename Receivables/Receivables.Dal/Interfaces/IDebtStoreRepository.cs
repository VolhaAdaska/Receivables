using System.Collections.Generic;
using Receivables.Dal.Models;

namespace Receivables.Dal.Interfaces
{
    public interface IDebtStoreRepository : IBaseRepository<DebtStore>
    {
        IList<DebtStore> GetByDebtId(int id);
    }
}
