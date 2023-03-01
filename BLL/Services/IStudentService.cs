using BLL.Models;

namespace BLL.Services
{
    public interface IStudentService
    {
        int AddStudent(StudentModel student);
        StudentModel GetStudentById(int id);
        List<StudentModel> Get();
        void Update(int id, StudentModel student);
    }
}
