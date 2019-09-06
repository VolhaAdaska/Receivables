using System.Collections.Generic;
using Receivables.Dal.Models;

namespace Receivables.Dal.Interfaces
{
    public interface IAgreementRepository : IBaseRepository<Agreement>
    {
        IEnumerable<Agreement> GetActiveAgreement(int customerId);
    }
}
