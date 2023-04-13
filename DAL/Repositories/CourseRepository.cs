using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public interface ICourseRepository
    {
        public int Add(Course course);
        public void Update(int id, Course course);
        public List<Course> Get();
        public Course? GetById(int id);
    }

    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly MyContext context;

        public CourseRepository(MyContext context)
        {
            this.context = context;
        }

        public override int Add(Course course)
        {
            context.Course.Add(course);
            context.SaveChanges();

            return course.CourseId;
        }

        public override void Update(int id, Course course)
        {
            var entity = context.Course.Find(id);
            if (entity == null)
                return;

            entity.CourseTypeName = course.CourseTypeName;
            entity.TeacherId = course.TeacherId;
            entity.Salary = course.Salary;

            context.SaveChanges();
        }

        public override List<Course> Get()
        {
            List<Course> coursesGet = new List<Course>();

            coursesGet = context.Course
                .AsNoTracking()
                .ToList();

            return coursesGet;
        }

        public override Course? GetById(int id)
        {
            Course? course = new Course();

            course = context.Course
                .Include(c => c.Institute)
                .Include(c => c.Teacher)
                .AsNoTracking()
                .FirstOrDefault(x => x.CourseId == id);

            return course;
        }
    }
}
