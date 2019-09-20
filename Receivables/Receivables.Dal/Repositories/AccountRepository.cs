using System.Collections.Generic;
using System.Linq;
using Receivables.Dal.Context;
using Receivables.Dal.Interfaces;
using Receivables.Dal.Models;

namespace Receivables.Dal.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(ReceivablesContext context)
         : base(context)
        {
        }

        public IList<Account> GetAccountByCustomerId(int customerId)
        {
            return entities.Where(x => x.CustomerId == customerId).ToList();
        }
    }
}
