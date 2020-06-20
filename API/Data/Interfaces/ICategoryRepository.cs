using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Data.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<Category> Get(int id);
        Task<object> Add(Category category);
        Task<object> Update(Category category);
        Task<object> Delete(Category category);
    }
}