using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBaseRepository<T>
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<IQueryable<T>> GetActivesAsync();
        IQueryable<T> GetActives();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T model);
        Task DeleteAsync(int id);
        Task UpdateAsync(T model);
    }
}
