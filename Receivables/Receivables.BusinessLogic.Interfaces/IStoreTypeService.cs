using System.Collections.Generic;
using Receivables.DTO;
using Receivables.BusinessLogic.Infrastructure;
using System.Threading.Tasks;
using System;

namespace Receivables.BusinessLogic.Interfaces
{
    public interface IStoreTypeService : IDisposable
    {
        Task<OperationDetails> AddStoreTypeAsync(StoreTypeDto storeTypeDto);

        Task<OperationDetails> UpdateStoreTypeAsync(StoreTypeDto storeTypeDto);

        Task<StoreTypeDto> GetStoreTypeByIdAsync(int id);

        Task<OperationDetails> DeleteStoreTypeAsync(StoreTypeDto storeTypeDto);

        IList<StoreTypeDto> GetAllStoreType();
    }
}
