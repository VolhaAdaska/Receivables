using System.Collections.Generic;
using Receivables.Dal.Models;

namespace Receivables.Dal.Interfaces
{
    public interface IDebtPaidRepository : IBaseRepository<DebtPaid>
    {
        IList<DebtPaid> GetByDebtId(int id);
    }
}
