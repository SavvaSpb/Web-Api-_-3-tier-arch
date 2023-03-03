using DAL.Context;
using DAL.Entities;
using Microsoft.Data.SqlClient;
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

            try
            {
                context.Course.Add(course);
                context.SaveChanges();
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine();
            }

            return course.CourseId;
        }

        public override void Update(int id, Course course)
        {
            try
            {
                var entity = context.Course.Find(id);
                if (entity == null)
                    return;

               entity.CourseId = course.CourseId;
               entity.CourseTypeName = course.CourseTypeName;
               entity.InstituteId = course.InstituteId;
               entity.TeacherId= course.TeacherId;
               entity.Salary = course.Salary;

                context.Course.Update(entity);
                context.SaveChanges();
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine();
            }
        }

        public override List<Course> Get()
        {
            List<Course> coursesGet = new List<Course>();

            try
            {
                coursesGet = context.Course
                    .AsNoTracking()
                    .ToList();

            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine();
            }

            return coursesGet;

        }

        public override Course? GetById(int id)
        {
            Course? course = new Course();
            try
            {
                course = context.Course
                    .Include(c => c.Institute)
                    .Include(c => c.Teacher)
                    .AsNoTracking()
                    .FirstOrDefault(x => x.CourseId == id);
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine();
            }

            return course;

        }
    }
}
