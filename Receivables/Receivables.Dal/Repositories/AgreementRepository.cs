using System.Collections.Generic;
using System.Linq;
using Receivables.Dal.Context;
using Receivables.Dal.Interfaces;
using Receivables.Dal.Models;

namespace Receivables.Dal.Repositories
{
    public class AgreementRepository : BaseRepository<Agreement>, IAgreementRepository
    {
        public AgreementRepository(ReceivablesContext context)
         : base(context)
        {
        }

        public IEnumerable<Agreement> GetActiveAgreement(int customerId)
        {
            return entities.Where(x => x.CustomerId == customerId && x.IsClosed == false);
        }
    }
}