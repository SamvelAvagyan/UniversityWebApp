using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBaseRepository<T>
    {
        Task<IQueryable<T>> GetAllAsync();
        void AddAsync(T model);
        void DeleteAsync(int id);
        void UpdateAsync(T model);
    }
}
