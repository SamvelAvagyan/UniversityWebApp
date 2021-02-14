using Repository.Models;

namespace Repository.Impl
{
    class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(UniversityDbContext dbContext)
            : base(dbContext)
        { }
    }
}
