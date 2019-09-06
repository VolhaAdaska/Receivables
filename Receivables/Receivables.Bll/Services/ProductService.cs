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
    public class ProductService : BaseService, IProductService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
           : base(unitOfWork, mapper)
        {
        }

        public async Task<OperationDetails> AddProductAsync(ProductDto productDto)
        {
            if (productDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "Product");
            }

            Product product = mapper.Map<ProductDto, Product>(productDto);
            try
            {
                if (unitOfWork.ProductRepository.GetByCode(product.Code) != null)
                {
                    Logger.Error("Номенклатура с таким артикулом уже существует");
                    return new OperationDetails(false, "Номенклатура с таким артикулом уже существует", "Product");
                }
                await unitOfWork.ProductRepository.CreateAsync(product);
                await unitOfWork.SaveAsync();
                Logger.Info("Successfully added");
                return new OperationDetails(true);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "Product");
            }
        }

        public async Task<OperationDetails> DeleteProductAsync(ProductDto productDto)
        {
            if (productDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "Product");
            }

            Product product = await unitOfWork.ProductRepository.GetByIdAsync(productDto.Id);
            if (product == null)
            {
                Logger.Error("Номенклатура не найдена");
                return new OperationDetails(false, "Номенклатура не найдена", "Product");
            }

            try
            {
                await unitOfWork.ProductRepository.DeleteAsync(product);
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

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            Product product = await unitOfWork.ProductRepository.GetByIdAsync(id);
            return mapper.Map<Product, ProductDto>(product);
        }

        public async Task<OperationDetails> UpdateProductAsync(ProductDto productDto)
        {
            if (productDto == null)
            {
                Logger.Error("Something went wrong");
                return new OperationDetails(false, "К сожалению, что-то пошло не так....", "Product");
            }

            Product product = mapper.Map<ProductDto, Product>(productDto);

            try
            {
                await unitOfWork.ProductRepository.UpdateAsync(product);
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
