using System.Collections.Generic;
using Receivables.Dal.Models;

namespace Receivables.Dal.Interfaces
{
    public interface IDebtRepository : IBaseRepository<Debt>
    {
        IList<Debt> GetAll();

        IList<Debt> GetActiveDebt(string status);
    }
}