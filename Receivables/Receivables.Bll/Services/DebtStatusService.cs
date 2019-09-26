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
    public class DebtStatusService : BaseService, IDebtStatusService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public DebtStatusService(IUnitOfWork unitOfWork, IMapper mapper)
           : base(unitOfWork, mapper)
        {
        }

        public async Task<OperationDetails> AddDebtStatusAsync(DebtStatusDto DebtStatusDto)
        {
            if (DebtStatusDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "DebtStatus");
            }

            DebtStatus DebtStatus = mapper.Map<DebtStatusDto, DebtStatus>(DebtStatusDto);
            try
            {
                //if (unitOfWork.DebtStatusRepository.GetByCode(DebtStatus.Code) != null)
                //{
                //    Logger.Error("Номенклатура с таким артикулом уже существует");
                //    return new OperationDetails(false, "Номенклатура с таким артикулом уже существует", "DebtStatus");
                //}
                await unitOfWork.DebtStatusRepository.CreateAsync(DebtStatus);
                await unitOfWork.SaveAsync();
                Logger.Info("Successfully added");
                return new OperationDetails(true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "DebtStatus");
            }
        }

        public async Task<OperationDetails> DeleteDebtStatusAsync(DebtStatusDto DebtStatusDto)
        {
            if (DebtStatusDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "DebtStatus");
            }

            DebtStatus DebtStatus = await unitOfWork.DebtStatusRepository.GetByIdAsync(DebtStatusDto.Id);
            if (DebtStatus == null)
            {
                Logger.Error("Номенклатура не найдена");
                return new OperationDetails(false, "Номенклатура не найдена", "DebtStatus");
            }

            try
            {
                await unitOfWork.DebtStatusRepository.DeleteAsync(DebtStatus);
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

        public async Task<DebtStatusDto> GetDebtStatusByIdAsync(int id)
        {
            DebtStatus DebtStatus = await unitOfWork.DebtStatusRepository.GetByIdAsync(id);
            return mapper.Map<DebtStatus, DebtStatusDto>(DebtStatus);
        }

        public async Task<OperationDetails> UpdateDebtStatusAsync(DebtStatusDto DebtStatusDto)
        {
            if (DebtStatusDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "DebtStatus");
            }

            DebtStatus DebtStatus = mapper.Map<DebtStatusDto, DebtStatus>(DebtStatusDto);

            try
            {
                await unitOfWork.DebtStatusRepository.UpdateAsync(DebtStatus);
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
