using Repository.Models;

namespace Repository.Impl
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(UniversityDbContext dbContext)
            : base(dbContext)
        { }
    }
}
