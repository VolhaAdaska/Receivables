using System;
using System.Threading.Tasks;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;

namespace Receivables.Bll.Interfaces
{
    public interface IStoreService : IDisposable
    {
        Task<OperationDetails> AddStoreAsync(StoreDto storeDto);

        Task<OperationDetails> DeleteStoreAsync(StoreDto storeDto);

        Task<OperationDetails> UpdateStoreAsync(StoreDto storeDto);

        Task<StoreDto> GetStoreByIdAsync(int id);

    }
}