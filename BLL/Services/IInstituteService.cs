using BLL.Models;

namespace BLL.Services
{
    public interface IInstituteService
    {
        int AddInstitute(InstituteModel institute);
        InstituteModel GetInstituteById(int id);
        List<InstituteModel> Get();
        void Update(int id, InstituteModel course);
    }
}
