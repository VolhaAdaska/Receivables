using AutoMapper;
using NLog;
using Receivables.BusinessLogic.Infrastructure;
using Receivables.BusinessLogic.Interfaces;
using Receivables.Dal.Interfaces;
using Receivables.DAL.Models;
using Receivables.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Receivables.BusinessLogic.Services
{
    public class StoreTypeService : BaseService, IStoreTypeService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public StoreTypeService(IUnitOfWork unitOfWork, IMapper mapper)
           : base(unitOfWork, mapper)
        {
        }

        public async Task<OperationDetails> AddStoreTypeAsync(StoreTypeDto storeTypeDto)
        {
            if (storeTypeDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "Something went wrong", "Store");
            }

            StoreType storeType = mapper.Map<StoreTypeDto, StoreType>(storeTypeDto);

            try
            {
                if (unitOfWork.StoreTypeRepository.GetByName(storeType.Name) != null)
                {
                    Logger.Error("A Store type with this name already exists");
                    return new OperationDetails(false, "A Store type with this name already exists", "StoreType");
                }
                await unitOfWork.StoreTypeRepository.CreateAsync(storeType);
                await unitOfWork.SaveAsync();
                Logger.Info("Successfully added");
                return new OperationDetails(true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new OperationDetails(false, "Unfortunately, something went wrong....", "StoreType");
            }
        }

        public async Task<OperationDetails> DeleteStoreTypeAsync(StoreTypeDto storeTypeDto)
        {
            if (storeTypeDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "Something went wrong", "Store");
            }

            StoreType storeType = await unitOfWork.StoreTypeRepository.GetByIdAsync(storeTypeDto.Id);
            if (storeType == null)
            {
                Logger.Error("Store type not found");
                return new OperationDetails(false, "Store type not found", "Store");
            }

            try
            {
                await unitOfWork.StoreTypeRepository.DeleteAsync(storeType);
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

        public async Task<OperationDetails> UpdateStoreTypeAsync(StoreTypeDto storeTypeDto)
        {
            if (storeTypeDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "Something went wrong", "Store");
            }

            StoreType storeType = mapper.Map<StoreTypeDto, StoreType>(storeTypeDto);
            try
            {
                await unitOfWork.StoreTypeRepository.UpdateAsync(storeType);
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

        public IList<StoreTypeDto> GetAllStoreType()
        {
            var result = unitOfWork.StoreTypeRepository.GetAllStoreType();
            return result.Select(p => mapper.Map<StoreType, StoreTypeDto>(p)).ToList();
        }

        public async Task<StoreTypeDto> GetStoreTypeByIdAsync(int id)
        {
            StoreType storeType = await unitOfWork.StoreTypeRepository.GetByIdAsync(id);
            return mapper.Map<StoreType, StoreTypeDto>(storeType);
        }

    }
}