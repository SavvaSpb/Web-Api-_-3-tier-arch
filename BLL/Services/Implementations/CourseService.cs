using ASP.NET_Core_EF_CodeFirst.Models;
using DAL.Repositories;

namespace BLL.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository repo;

        public CourseService(ICourseRepository repo)
        {
            this.repo = repo;
        }

       public CourseModel GetCourseById(int id)
        {
            var courseEntity = repo.GetById(id);
            if (courseEntity == null)
            {
                //throw new CustomException("Course doesn't exist");
            }

            //var external = ;

            return new CourseModel
            {
                CoursesId = courseEntity.CoursesId
            };
        }
    }
}
