using BLL.Models;
using BLL.Models.Exceptions;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Services.Implementations
{
    public class InstituteService : IInstituteService
    {
        private readonly IInstituteRepository instituteRepo;
        public InstituteService(IInstituteRepository repo)
        {
            this.instituteRepo = repo;
        }

        public int AddInstitute(InstituteModel institute)
        {
            Institute instituteEntity = new Institute
            {
                InstituteTypeName = institute.InstituteTypeName
            };

            int instituteId = instituteRepo.Add(instituteEntity);

            return instituteId;
        }

        public InstituteModel GetInstituteById(int id)
        {
            var instituteEntity = instituteRepo.GetById(id);
            if (instituteEntity == null)
            {
                throw new ValidationException("Institute doesn't exist");
            }

            return new InstituteModel
            {
                InstituteId = instituteEntity.InstituteId,
                InstituteTypeName = instituteEntity.InstituteTypeName
            };
        }

        public List<InstituteModel> Get()
        {
            List<Institute> instituteEntities = instituteRepo.Get();

            if (!instituteEntities.Any())
            {
                throw new ValidationException("We have no any institute");
            }

            var institutions = new List<InstituteModel>();

            foreach (var item in instituteEntities)
            {
                institutions.Add(new InstituteModel { InstituteTypeName = item.InstituteTypeName });
            }
            return institutions;
        }

        public void Update(int id, InstituteModel institute)
        {
            var instituteEntity = new Institute
            {
                InstituteId = id,
                InstituteTypeName = institute.InstituteTypeName
            };

            instituteRepo.Update(id, instituteEntity);
        }
    }
}
