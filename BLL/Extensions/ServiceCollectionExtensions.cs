using BLL.Services;
using BLL.Services.Implementations;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extensions
{
    public static class ServieCollectionExtensions
    {
        public static void AddLocalServices(this IServiceCollection services)
        {
            // BLL
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IInstituteService, InstituteService>();

            // DAL 
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IInstituteRepository, InstituteRepository>();
        }
    }
}
