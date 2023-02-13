using ASP.NET_Core_EF_CodeFirst.Models;

namespace BLL.Services
{
    public interface ICourseService
    {
        CourseModel GetCourseById(int id);
    }
}
