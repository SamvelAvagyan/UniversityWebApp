using Repository.Models;

namespace Repository.Impl
{
    public class UniversityRepository : BaseRepository<University>, IUniversityRepository
    {
        public UniversityRepository(UniversityDbContext dbContext)
            : base(dbContext)
        { }
    }
}
