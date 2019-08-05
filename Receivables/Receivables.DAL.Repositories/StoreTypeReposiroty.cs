using Receivables.Dal.Context;
using Receivables.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using Receivables.DAL.Interfaces.Repositories;

namespace Receivables.DAL.Repositories
{
    public class StoreTypeReposiroty : BaseRepository<StoreType>, IStoreTypeRepository
    {
        public StoreTypeReposiroty(GodelBenefitContext context)
            : base(context)
        {
        }

        public IList<StoreType> GetAllStoreType()
        {
            return entities.ToList();
        }

        public StoreType GetByName(string storeTypeName)
        {
            return entities.FirstOrDefault(x => x.Name.Equals(storeTypeName, System.StringComparison.InvariantCultureIgnoreCase));
        }
    }
}