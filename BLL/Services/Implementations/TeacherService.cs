using DAL.Repositories;

namespace BLL.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository repo;
        public TeacherService(ITeacherRepository repo)
        {
            this.repo = repo;
        }

    }
}
