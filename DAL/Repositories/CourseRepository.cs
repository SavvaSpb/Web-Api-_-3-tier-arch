using DAL.Entities;
using DAL.MyContext;
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
        public override int Add(Course course)
        {
            using (var context = new Context())
            {
                try
                {
                    context.Courses.Add(course);
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

                return course.CoursesId;
            }
        }

        public override void Update(int id, Course course)
        {
            using (var context = new Context())
            {
                try
                {
                    var entity = context.Courses.Find(id);
                    if (entity == null)
                        return;

                    entity.Salary = course.Salary;
                    context.Courses.Update(entity);
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
        }

        public override List<Course> Get()
        {
            List<Course> coursesGet = new List<Course>();

            using (var context = new Context())
            {
                try
                {
                    coursesGet = context.Courses
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
        }

        public override Course? GetById(int id)
        {
            Course? course = new Course();

            using (var context = new Context())
            {
                try
                {
                    course = context.Courses
                        .AsNoTracking()
                        .FirstOrDefault(x => x.CoursesId == id);
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
}
