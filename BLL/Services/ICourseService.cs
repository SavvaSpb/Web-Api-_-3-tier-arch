using BLL.Models;

namespace BLL.Services
{
    public interface ICourseService
    {
        int AddCourse(CourseModel course);
        CourseModel GetCourseById(int id);
        List<CourseModel> Get();
        void Update(int id, CourseModel course);
    }
}
