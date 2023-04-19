using BLL.Models;
using BLL.Models.Exceptions;
using DAL.Entities;
using DAL.Models;
using DAL.Repositories;

namespace BLL.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository teacherRepo;
        public TeacherService(ITeacherRepository repo)
        {
            this.teacherRepo = repo;
        }

        public int AddTeacher(TeacherModel teacher)
        {
            Teacher teacherEntity = new Teacher
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Birthday = teacher.Birthday,
                Address = teacher.Address,
                Phone = teacher.Phone,
                Email = teacher.Email
            };

            int teacherId = teacherRepo.Add(teacherEntity);

            return teacherId;
        }

        public TeacherModel GetTeacherById(int id)
        {
            var teacherEntity = teacherRepo.GetById(id);
            if (teacherEntity == null)
            {
                throw new ValidationException("Teacher doesn't exist");
            }

            return new TeacherModel
            {
                Id = teacherEntity.TeacherId,
                FirstName = teacherEntity.FirstName,
                LastName = teacherEntity.LastName,
                Birthday = teacherEntity.Birthday,
                Address = teacherEntity.Address,
                Phone = teacherEntity.Phone,
                Email = teacherEntity.Email
            };
        }

        public List<TeacherModel> Get()
        {
            List<Teacher> teacherEntities = teacherRepo.Get();

            if (!teacherEntities.Any())
            {
                throw new ValidationException("We have no any teacher");
            }

            var teachers = new List<TeacherModel>();

            foreach (var item in teacherEntities)
            {
                teachers.Add(new TeacherModel
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Birthday = item.Birthday,
                    Address = item.Address,
                    Phone = item.Phone,
                    Email = item.Email
                });
            }
            return teachers;
        }

        public void Update(int id, TeacherModel teacher)
        {
            var teacherEntity = new Teacher
            {
                TeacherId = id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Birthday = teacher.Birthday,
                Address = teacher.Address,
                Phone = teacher.Phone,
                Email = teacher.Email
            };

            teacherRepo.Update(id, teacherEntity);
        }

        public List<TeacherModel> GetWithSalary()
        {
            List<TeacherWithSalaryModel> teacherEntities = teacherRepo.GetWithSalary();

            if (!teacherEntities.Any())
            {
                throw new ValidationException("We have no any teachers");
            }

            var teachers = new List<TeacherModel>();

            foreach (var item in teacherEntities)
            {
                teachers.Add(new TeacherModel
                {
                    Id = item.TeacherId,
                    TotalSalary = item.TotalSalary,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Birthday = item.Birthday,
                    Address = item.Address,
                    Phone = item.Phone,
                    Email = item.Email
                });
            }
            return teachers;
        }
    }
}
