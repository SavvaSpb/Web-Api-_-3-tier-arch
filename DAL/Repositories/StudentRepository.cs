using DAL.Entities;
using DAL.MyContext;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public interface IStudentRepository
    {
        public int Add(Student student);
        public void Update(int id, Student student);
        public List<Student> Get();
        public Student GetById(int id);
    }
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public override int Add(Student student)
        {
            using (var context = new Context())
            {
                try
                {
                    context.Students.Add(student);
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

                return student.StudentsId;
            }
        }

        public override void Update(int id, Student student)
        {
            using (var context = new Context())
            {
                try
                {
                    context.Students.Find(id, student);
                    context.Students.Update(student);
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

        public override List<Student> Get()
        {
            List<Student> studentsGet = new List<Student>();

            using (var context = new Context())
            {
                try
                {
                    studentsGet = context.Students.ToList();
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

                return studentsGet;
            }
        }

        public override Student GetById(int id)
        {
            Student student = new Student();

            using (var context = new Context())
            {
                try
                {
                    student = context.Students.Find(id);
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

                return student;
            }
        }
    }
}
