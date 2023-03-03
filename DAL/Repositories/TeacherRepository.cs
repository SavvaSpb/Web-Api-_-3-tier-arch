using DAL.Context;
using DAL.Entities;
using DAL.Models;
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
        public List<TeacherWithSalaryModel> GetWithSalary();

    }
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private readonly MyContext context;

        public TeacherRepository(MyContext context)
        {
            this.context = context;
        }

        public override int Add(Teacher teacher)
        {

            try
            {
                context.Teacher.Add(teacher);
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

            return teacher.TeacherId;

        }

        public override void Update(int id, Teacher teacher)
        {

            try
            {
                var entity = context.Teacher.Find(id);
                if (entity == null)
                    return;

                entity.FirstName = teacher.FirstName;
                entity.LastName = teacher.LastName;
                entity.Birthday = teacher.Birthday;
                entity.Address = teacher.Address;
                entity.Phone = teacher.Phone;
                entity.Email = teacher.Email;

                context.Teacher.Update(entity);
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

        public override List<Teacher> Get()
        {
            List<Teacher> teachersGet = new List<Teacher>();

            try
            {
                teachersGet = context.Teacher
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

            return teachersGet;

        }

        public override Teacher GetById(int id)
        {
            Teacher teacher = new Teacher();

            try
            {
                teacher = context.Teacher
                    .AsNoTracking()
                    .FirstOrDefault(x => x.TeacherId == id);
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

        public List<TeacherWithSalaryModel> GetWithSalary()
        {
            IQueryable<TeacherWithSalaryModel> query = (from t in context.Teacher
                                                        join c in context.Course
                                                        on t.TeacherId equals c.TeacherId
                                                        select new
                                                        {
                                                            t,
                                                            c
                                                        } into tc
                                                        group tc by tc.t.TeacherId into g
                                                        orderby g.Key /* ascending */
                                                        select new TeacherWithSalaryModel
                                                        {
                                                            TeacherId = g.Key,
                                                            TotalSalary = g.Sum(x => x.c.Salary),
                                                            FirstName = g.Min(x => x.t.FirstName),
                                                            LastName = g.Min(x => x.t.LastName),
                                                            Birthday = g.Min(x => x.t.Birthday),
                                                            Address = g.Min(x => x.t.Address),
                                                            Phone = g.Min(x => x.t.Phone),
                                                            Email = g.Min(x => x.t.Email)

                                                        } );

            string queryString = query.ToQueryString();
            Console.WriteLine(queryString);
            return query.ToList();
        }

    }
}
