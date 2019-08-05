using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receivables.Bll.Interfaces
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
