using System.Threading.Tasks;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;

namespace Receivables.Bll.Interfaces
{
    public interface IDebtClaimService
    {
        Task<OperationDetails> AddDebtClaimAsync(DebtClaimDto DebtClaimDto);

        Task<OperationDetails> DeleteDebtClaimAsync(DebtClaimDto DebtClaimDto);

        Task<OperationDetails> UpdateDebtClaimAsync(DebtClaimDto DebtClaimDto);

        Task<DebtClaimDto> GetDebtClaimByIdAsync(int id);
    }
}
