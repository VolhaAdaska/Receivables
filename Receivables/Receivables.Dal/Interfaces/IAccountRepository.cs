using System.Collections.Generic;
using System.Linq;
using Receivables.Dal.Models;

namespace Receivables.Dal.Interfaces
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        IList<Account> GetAccountByCustomerId(int customerId);
    }
}