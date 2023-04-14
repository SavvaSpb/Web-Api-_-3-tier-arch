using BLL.Models;
using BLL.Services;
using BLL.Services.Implementations;
using DAL.Context;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extensions
{
    public static class ServieCollectionExtensions
    {
        public static void AddLocalServices(this IServiceCollection services)
        {
            services.RegisterAsOptions<JwtModel>("Jwt");

            // DB Context registration
            services.AddDbContext<MyContext>(
                options => options.UseSqlServer("name=ConnectionStrings:MyConnection"));

            // BLL
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IInstituteService, InstituteService>();
            services.AddScoped<IUserAccountService, UserAccountService>();

            // DAL 
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IInstituteRepository, InstituteRepository>();
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
        }

        private static void RegisterAsOptions<T>(this IServiceCollection services, string sectionName) where T : class
        {
            if (sectionName == null)
            {
                return;
            }

            services.AddOptions<T>().Configure<IConfiguration>((settings, config) => { config.GetSection(sectionName).Bind(settings); });
        }
    }
}
