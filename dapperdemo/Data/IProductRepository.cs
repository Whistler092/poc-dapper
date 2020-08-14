using System.Collections.Generic;
using System.Threading.Tasks;

namespace dapperdemo.Data
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();

        Task<Product> GetById(int id);

        Task<Product> Add(Product product);

        Task Delete(int id);
    }
}
