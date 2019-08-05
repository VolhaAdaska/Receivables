using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Receivables.BusinessLogic.Infrastructure;
using Receivables.DTO;

namespace Receivables.Bll.Interfaces
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