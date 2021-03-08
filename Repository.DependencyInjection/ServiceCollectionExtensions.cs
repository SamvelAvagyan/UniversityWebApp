using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Impl;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<UniversityDbContext>(con => con.UseSqlServer(connectionString));
            services.AddScoped<DbContext, UniversityDbContext>();
            return services;
        }

        public static IServiceCollection AddRepositoryContracts(this IServiceCollection services)
            => services
                .AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>))
                .AddScoped<IStudentRepository, StudentRepository>()
                .AddScoped<ITeacherRepository, TeacherRepository>()
                .AddScoped<IUniversityRepository, UniversityRepository>();

        public static IServiceCollection AddRepository(this IServiceCollection services, string connectionString)
            => services
                .AddDbContext(connectionString)
                .AddRepositoryContracts();
    }
}
