using BLL.Models;

namespace BLL.Services
{
    public interface ITeacherService
    {
        int AddTeacher(TeacherModel teacher);
        TeacherModel GetTeacherById(int id);
        List<TeacherModel> Get();
        void Update(int id, TeacherModel teacher);
        List<TeacherModel> GetWithSalary();
    }
}
