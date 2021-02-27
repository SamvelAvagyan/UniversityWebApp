using Repository.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseModel
    {
        private readonly UniversityDbContext dbContext;

        public BaseRepository(UniversityDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(T model)
        {
            dbContext.Set<T>().Add(model);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            dbContext.Set<T>().Find(id).Active = false;
            await dbContext.SaveChangesAsync();
        }

        public IQueryable<T> GetActives()
        {
            return dbContext.Set<T>().Where(t => t.Active);
        }

        public async Task<IQueryable<T>> GetActivesAsync()
        {
            return await Task.Run(() =>
            {
                return dbContext.Set<T>().Where(t => t.Active);
            });
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return dbContext.Set<T>();
            });
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Task.Run(() =>
            {
                return dbContext.Set<T>().Find(id);
            });
        }

        public async Task UpdateAsync(T model)
        {
            model.ModifiedOn = DateTime.Now;
            model.Active = true;
            dbContext.Set<T>().Update(model);
            await dbContext.SaveChangesAsync();
        }
    }
}
