using System;
using System.Threading.Tasks;
using Receivables.Bll.Dto;
using Receivables.Bll.Infrastructure;

namespace Receivables.Bll.Interfaces
{
    public interface IProductService : IDisposable
    {
        Task<OperationDetails> AddProductAsync(ProductDto productDto);

        Task<OperationDetails> DeleteProductAsync(ProductDto productDto);

        Task<OperationDetails> UpdateProductAsync(ProductDto productDto);

        Task<ProductDto> GetProductByIdAsync(int id);
    }
}
