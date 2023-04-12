using DAL.Context;
using DAL.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public interface IInstituteRepository
    {
        public int Add(Institute institute);
        public void Update(int id, Institute institute);
        public List<Institute> Get();
        public Institute GetById(int id);
    }
    public class InstituteRepository : Repository<Institute>, IInstituteRepository
    {
        private readonly MyContext context;

        public InstituteRepository(MyContext context)
        {
            this.context = context;
        }

        public override int Add(Institute institute)
        {

                context.Institute.Add(institute);
                context.SaveChanges();

            return institute.InstituteId;

        }

        public override void Update(int id, Institute institute)
        {
            
                var entity = context.Institute.Find(id);
                if (entity == null)
                    return;

                entity.InstituteTypeName = institute.InstituteTypeName;

                context.SaveChanges();

        }

        public override List<Institute> Get()
        {
            List<Institute> institutesGet = new List<Institute>();

                institutesGet = context.Institute
                    .AsNoTracking()
                    .ToList();
               
            return institutesGet;

        }

        public override Institute GetById(int id)
        {
            Institute institute = new Institute();

                institute = context.Institute
                    .AsNoTracking()
                    .FirstOrDefault(x => x.InstituteId == id);

            return institute;

        }
    }
}
