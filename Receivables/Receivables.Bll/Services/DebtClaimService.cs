using System;
using System.Threading.Tasks;
using AutoMapper;
using NLog;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;
using Receivables.Bll.Interfaces;
using Receivables.Dal.Interfaces;
using Receivables.Dal.Models;

namespace Receivables.Bll.Services
{
    public class DebtClaimService : BaseService, IDebtClaimService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public DebtClaimService(IUnitOfWork unitOfWork, IMapper mapper)
           : base(unitOfWork, mapper)
        {
        }

        public async Task<OperationDetails> AddDebtClaimAsync(DebtClaimDto DebtClaimDto)
        {
            if (DebtClaimDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "DebtClaim");
            }

            DebtClaim DebtClaim = mapper.Map<DebtClaimDto, DebtClaim>(DebtClaimDto);
            try
            {
                //if (unitOfWork.DebtClaimRepository.GetByCode(DebtClaim.Code) != null)
                //{
                //    Logger.Error("Номенклатура с таким артикулом уже существует");
                //    return new OperationDetails(false, "Номенклатура с таким артикулом уже существует", "DebtClaim");
                //}
                await unitOfWork.DebtClaimRepository.CreateAsync(DebtClaim);
                await unitOfWork.SaveAsync();
                Logger.Info("Successfully added");
                return new OperationDetails(true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "DebtClaim");
            }
        }

        public async Task<OperationDetails> DeleteDebtClaimAsync(DebtClaimDto DebtClaimDto)
        {
            if (DebtClaimDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "DebtClaim");
            }

            DebtClaim DebtClaim = await unitOfWork.DebtClaimRepository.GetByIdAsync(DebtClaimDto.Id);
            if (DebtClaim == null)
            {
                Logger.Error("Номенклатура не найдена");
                return new OperationDetails(false, "Номенклатура не найдена", "DebtClaim");
            }

            try
            {
                await unitOfWork.DebtClaimRepository.DeleteAsync(DebtClaim);
                await unitOfWork.SaveAsync();
                Logger.Info("Successfully deleted");
                return new OperationDetails(true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new OperationDetails(false, ex.Message);
            }
        }

        public async Task<DebtClaimDto> GetDebtClaimByIdAsync(int id)
        {
            DebtClaim DebtClaim = await unitOfWork.DebtClaimRepository.GetByIdAsync(id);
            return mapper.Map<DebtClaim, DebtClaimDto>(DebtClaim);
        }

        public async Task<OperationDetails> UpdateDebtClaimAsync(DebtClaimDto DebtClaimDto)
        {
            if (DebtClaimDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "DebtClaim");
            }

            DebtClaim DebtClaim = mapper.Map<DebtClaimDto, DebtClaim>(DebtClaimDto);

            try
            {
                await unitOfWork.DebtClaimRepository.UpdateAsync(DebtClaim);
                await unitOfWork.SaveAsync();
                Logger.Info("Successfully updated");
                return new OperationDetails(true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new OperationDetails(false, ex.Message);
            }
        }
    }
}
