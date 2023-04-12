using BLL.Models;
using BLL.Models.Exceptions;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository repo;
        public StudentService(IStudentRepository repo)
        {
            this.repo = repo;
        }

        public int AddStudent(StudentModel student)
        {
            Student studentEntity = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Birthday = student.Birthday,
                Address = student.Address,
                Phone = student.Phone,
                Email = student.Email
            };

            int studentId = repo.Add(studentEntity);

            return studentId;
        }

        public StudentModel GetStudentById(int id)
        {
            var studentEntity = repo.GetById(id);
            if (studentEntity == null)
            {
                throw new ValidationException("Student doesn't exist");
            }

            return new StudentModel
            {
                StudentId = studentEntity.StudentId,

                FirstName = studentEntity.FirstName,

                LastName = studentEntity.LastName,

                Birthday = studentEntity.Birthday,

                Address = studentEntity.Address,

                Phone = studentEntity.Phone,

                Email = studentEntity.Email

            };
        }

        public List<StudentModel> Get()
        {
            List<Student> studentEntities = repo.Get();

            if (!studentEntities.Any())
            {
                throw new ValidationException("We have no any student");
            }

            var students = new List<StudentModel>();

            foreach (var item in studentEntities)
            {
                students.Add(new StudentModel
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Birthday = item.Birthday,
                    Address = item.Address,
                    Phone = item.Phone,
                    Email = item.Email
                });
            }
            return students;
        }

        public void Update(int id, StudentModel student)
        {
            var studentEntity = new Student
            {
                StudentId = id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Birthday = student.Birthday,
                Address = student.Address,
                Phone = student.Phone,
                Email = student.Email
            };

            repo.Update(id, studentEntity);
        }
    }
}
