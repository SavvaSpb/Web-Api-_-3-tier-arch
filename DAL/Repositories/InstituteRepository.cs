using DAL.Entities;
using DAL.MyContext;
using Microsoft.Data.SqlClient;

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
        public override int Add(Institute institute)
        {
            using (var context = new Context())
            {
                try
                {
                    context.Institute.Add(institute);
                    context.SaveChanges();
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine(sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {

                    Console.WriteLine();
                }

                return institute.InstituteId;
            }
        }

        public override void Update(int id, Institute institute)
        {
            using (var context = new Context())
            {
                try
                {
                    context.Institute.Find(id, institute);
                    context.Institute.Update(institute);
                    context.SaveChanges();
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine(sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine();
                }
            }
        }

        public override List<Institute> Get()
        {
            List<Institute> institutesGet = new List<Institute>();

            using (var context = new Context())
            {
                try
                {
                    institutesGet = context.Institute.ToList();
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine(sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine();
                }

                return institutesGet;
            }
        }

        public override Institute GetById(int id)
        {
            Institute institute = new Institute();

            using (var context = new Context())
            {
                try
                {
                    institute = context.Institute.Find(id);
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine(sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine();
                }

                return institute;
            }
        }
    }
}
