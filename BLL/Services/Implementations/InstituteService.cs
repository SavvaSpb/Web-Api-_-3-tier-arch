using ASP.NET_Core_EF_CodeFirst.Models;
using DAL.Repositories;

namespace BLL.Services.Implementations
{
    public class InstituteService : IInstituteService
    {
        private readonly IInstituteRepository repo;
        public InstituteService(IInstituteRepository repo)
        {
            this.repo = repo;
        }


    }
}
