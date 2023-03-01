using DAL.Context;
using DAL.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
        private readonly MyContext context;

        public StudentRepository(MyContext context)
        {
            this.context = context;
        }

        public override int Add(Student student)
        {

            try
            {
                context.Student.Add(student);
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

            return student.StudentId;

        }

        public override void Update(int id, Student student)
        {
            try
            {
                var entity = context.Student.Find(id);
                if (entity == null)
                    return;

                entity.FirstName = student.FirstName;
                entity.LastName = student.LastName;
                entity.Birthday = student.Birthday;
                entity.Address = student.Address;
                entity.Phone = student.Phone;
                entity.Email = student.Email;

                context.Student.Update(entity);
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

        public override List<Student> Get()
        {
            List<Student> studentsGet = new List<Student>();

            try
            {
                studentsGet = context.Student
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

            return studentsGet;

        }

        public override Student GetById(int id)
        {
            Student student = new Student();

            try
            {
                student = context.Student
                    .AsNoTracking()
                    .FirstOrDefault(x => x.StudentId == id);
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
