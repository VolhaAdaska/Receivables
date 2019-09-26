using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Receivables.Dal.Context;
using Receivables.Dal.Interfaces;
using Receivables.Dal.Models;

namespace Receivables.Dal.Repositories
{
    public class DebtRepository : BaseRepository<Debt>, IDebtRepository
    {
        public DebtRepository(ReceivablesContext context)
          : base(context)
        {
        }

        public IList<Debt> GetActiveDebt(string status)
        {
            return entities.Where(x => !x.Status.Equals(status, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        public IList<Debt> GetAll()
        {
            return entities.ToList();
        }
    }
}
