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
    }
}
