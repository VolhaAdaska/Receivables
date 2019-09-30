using System;
using System.Linq;
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
    public class DebtPaidService : BaseService, IDebtPaidService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public DebtPaidService(IUnitOfWork unitOfWork, IMapper mapper)
           : base(unitOfWork, mapper)
        {
        }

        public async Task<OperationDetails> AddDebtPaidAsync(DebtPaidDto DebtPaidDto)
        {
            if (DebtPaidDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "DebtPaid");
            }

            DebtPaid DebtPaid = mapper.Map<DebtPaidDto, DebtPaid>(DebtPaidDto);
            try
            {
                //if (unitOfWork.DebtPaidRepository.GetByCode(DebtPaid.Code) != null)
                //{
                //    Logger.Error("Номенклатура с таким артикулом уже существует");
                //    return new OperationDetails(false, "Номенклатура с таким артикулом уже существует", "DebtPaid");
                //}
                await unitOfWork.DebtPaidRepository.CreateAsync(DebtPaid);
                await unitOfWork.SaveAsync();
                Logger.Info("Successfully added");
                return new OperationDetails(true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "DebtPaid");
            }
        }

        public async Task<OperationDetails> DeleteDebtPaidAsync(DebtPaidDto DebtPaidDto)
        {
            if (DebtPaidDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "DebtPaid");
            }

            DebtPaid DebtPaid = await unitOfWork.DebtPaidRepository.GetByIdAsync(DebtPaidDto.Id);
            if (DebtPaid == null)
            {
                Logger.Error("Номенклатура не найдена");
                return new OperationDetails(false, "Номенклатура не найдена", "DebtPaid");
            }

            try
            {
                await unitOfWork.DebtPaidRepository.DeleteAsync(DebtPaid);
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

        public DebtPaidDto GetDebtPaidByDebtId(int id)
        {
            var paids = unitOfWork.DebtPaidRepository.GetByDebtId(id);
            var debtDto = new DebtPaidDto
            {
                Sum = paids.Sum(x => x.Sum)
            };
            return debtDto;
        }

        public async Task<DebtPaidDto> GetDebtPaidByIdAsync(int id)
        {
            DebtPaid DebtPaid = await unitOfWork.DebtPaidRepository.GetByIdAsync(id);
            return mapper.Map<DebtPaid, DebtPaidDto>(DebtPaid);
        }

        public async Task<OperationDetails> UpdateDebtPaidAsync(DebtPaidDto DebtPaidDto)
        {
            if (DebtPaidDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "DebtPaid");
            }

            DebtPaid DebtPaid = mapper.Map<DebtPaidDto, DebtPaid>(DebtPaidDto);

            try
            {
                await unitOfWork.DebtPaidRepository.UpdateAsync(DebtPaid);
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
