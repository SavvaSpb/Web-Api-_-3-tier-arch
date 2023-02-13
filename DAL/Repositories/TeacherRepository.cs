using DAL.Entities;
using DAL.MyContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public interface ITeacherRepository
    {
        public int Add(Teacher teacher);
        public void Update(int id, Teacher teacher);
        public List<Teacher> Get();
        public Teacher GetById(int id);

    }
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public override int Add(Teacher teacher)
        {
            using (var context = new Context())
            {
                try
                {
                    context.Teachers.Add(teacher);
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

                return teacher.TeachersId;
            }
        }

        public override void Update(int id, Teacher teacher)
        {
            using (var context = new Context())
            {
                try
                {
                    context.Teachers.Find(id, teacher);
                    context.Teachers.Update(teacher);
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

        public override List<Teacher> Get()
        {
            List<Teacher> teachersGet = new List<Teacher>();

            using (var context = new Context())
            {
                try
                {
                    teachersGet = context.Teachers.ToList();
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

                return teachersGet;
            }
        }

        public override Teacher GetById(int id)
        {
            Teacher teacher = new Teacher();

            using (var context = new Context())
            {
                try
                {
                    teacher = context.Teachers.AsNoTracking().FirstOrDefault(x => x.TeachersId == id);
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

                return teacher;
            }
        }
    }
}
