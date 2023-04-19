using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    { }
    
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly MyContext context;

        public StudentRepository(MyContext context)
        {
            this.context = context;
        }

        public override int Add(Student student)
        {
                context.Student.Add(student);
                context.SaveChanges();

            return student.StudentId;
        }

        public override void Update(int id, Student student)
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

                context.SaveChanges();
        }

        public override List<Student> Get()
        {
            List<Student> studentsGet = new List<Student>();

                studentsGet = context.Student
                    .AsNoTracking()
                    .ToList();

            return studentsGet;
        }

        public override Student GetById(int id)
        {
            Student student = new Student();

                student = context.Student
                    .AsNoTracking()
                    .FirstOrDefault(x => x.StudentId == id);

            return student;
        }
    }
}
