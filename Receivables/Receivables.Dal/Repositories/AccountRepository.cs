using System;
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

        public IList<Account> GetAccountByCustomerId(int customerId, DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null)
            {
                startDate = DateTime.MinValue;
            }

            if (endDate == null)
            {
                endDate = DateTime.MaxValue;
            }

            return entities.Where(x => x.CustomerId == customerId
                                        && x.Date >= startDate.Value
                                        && x.Date < endDate.Value).ToList();
        }
    }
}
