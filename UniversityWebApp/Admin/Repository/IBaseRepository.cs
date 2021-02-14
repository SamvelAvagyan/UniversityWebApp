using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBaseRepository<T>
    {
        Task<IQueryable<T>> GetAllAsync();
        Task AddAsync(T model);
        Task DeleteAsync(int id);
        Task UpdateAsync(T model);
    }
}
