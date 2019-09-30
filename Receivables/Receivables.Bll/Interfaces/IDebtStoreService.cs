using System.Collections.Generic;
using System.Threading.Tasks;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;

namespace Receivables.Bll.Interfaces
{
    public interface IDebtStoreService
    {
        Task<OperationDetails> AddDebtStoreAsync(DebtStoreDto DebtStoreDto);

        Task<OperationDetails> DeleteDebtStoreAsync(DebtStoreDto DebtStoreDto);

        Task<OperationDetails> UpdateDebtStoreAsync(DebtStoreDto DebtStoreDto);

        Task<DebtStoreDto> GetDebtStoreByIdAsync(int id);

        IList<DebtStoreDto> GetDebtStoreByDebtId(int id);
    }
}