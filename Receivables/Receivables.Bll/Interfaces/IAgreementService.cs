using System.Collections.Generic;
using System.Threading.Tasks;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;

namespace Receivables.Bll.Interfaces
{
    public interface IAgreementService
    {
        Task<OperationDetails> AddAgreementAsync(AgreementDto AgreementDto);

        Task<OperationDetails> DeleteAgreementAsync(AgreementDto AgreementDto);

        Task<OperationDetails> UpdateAgreementAsync(AgreementDto AgreementDto);

        Task<AgreementDto> GetAgreementByIdAsync(int id);

        IEnumerable<AgreementDto> GetActiveAgreement(string userId);
    }
}