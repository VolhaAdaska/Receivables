using System.Collections.Generic;
using Receivables.DTO;
using Receivables.BusinessLogic.Infrastructure;
using System.Threading.Tasks;
using System;

namespace Receivables.BusinessLogic.Interfaces
{
    public interface IStoreService : IDisposable
    {
        Task<OperationDetails> AddStoreAsync(StoreDto storeDto);

        Task<OperationDetails> DeleteStoreAsync(StoreDto storeDto);

        Task<OperationDetails> UpdateStoreAsync(StoreDto storeDto);

        Task<StoreDto> GetStoreByIdAsync(int id);

        IList<StoreDto> GetAllStore(int storeTypeId);
    }
}