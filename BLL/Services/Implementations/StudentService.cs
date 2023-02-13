using ASP.NET_Core_EF_CodeFirst.Models;
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

        public static StudentModel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
