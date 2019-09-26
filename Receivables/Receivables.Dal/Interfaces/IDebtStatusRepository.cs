using System.Collections.Generic;
using Receivables.Dal.Models;

namespace Receivables.Dal.Interfaces
{
    public interface IDebtStatusRepository : IBaseRepository<DebtStatus>
    {
        IList<DebtStatus> GetByDebtId(int id);
    }
}
