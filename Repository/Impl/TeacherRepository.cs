using Repository.Models;

namespace Repository.Impl
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(UniversityDbContext dbContext)
            : base(dbContext)
        { }
    }
}
