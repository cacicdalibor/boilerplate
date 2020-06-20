using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Data.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> Get(int id);
        Task<object> Add(Product product);
        Task<object> Update(Product product);
        Task<object> Delete(Product product);
    }
}