using Repository.Models;

namespace Repository.Impl
{
    class UniversityRepository : BaseRepository<University>, IUniversityRepository
    {
        public UniversityRepository(UniversityDbContext dbContext)
            : base(dbContext)
        { }
    }
}
