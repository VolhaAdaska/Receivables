using Receivables.Dal.Models;

namespace Receivables.Dal.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Product GetByCode(int codeId);
    }
}
