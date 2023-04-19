using DAL.Context;
using DAL.Entities;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        public List<TeacherWithSalaryModel> GetWithSalary();
    }

    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private readonly MyContext context;

        public TeacherRepository(MyContext context)
        {
            this.context = context;
        }

        public override int Add(Teacher teacher)
        {
            context.Teacher.Add(teacher);
            context.SaveChanges();

            return teacher.TeacherId;
        }

        public override void Update(int id, Teacher teacher)
        {
            var entity = context.Teacher.Find(id);
            if (entity == null)
                return;

            entity.FirstName = teacher.FirstName;
            entity.LastName = teacher.LastName;
            entity.Birthday = teacher.Birthday;
            entity.Address = teacher.Address;
            entity.Phone = teacher.Phone;
            entity.Email = teacher.Email;

            context.SaveChanges();
        }

        public override List<Teacher> Get()
        {
            List<Teacher> teachersGet = new List<Teacher>();

            teachersGet = context.Teacher
                .AsNoTracking()
                .ToList();

            return teachersGet;
        }

        public override Teacher GetById(int id)
        {
            Teacher teacher = new Teacher();

            teacher = context.Teacher
                .AsNoTracking()
                .FirstOrDefault(x => x.TeacherId == id);

            return teacher;
        }

        public List<TeacherWithSalaryModel> GetWithSalary()
        {

            IQueryable<TeacherWithSalaryModel> query = (from t in context.Teacher
                                                        join c in context.Course
                                                        on t.TeacherId equals c.TeacherId
                                                        select new
                                                        {
                                                            t,
                                                            c
                                                        } into tc
                                                        group tc by tc.t.TeacherId into g
                                                        orderby g.Key
                                                        select new TeacherWithSalaryModel
                                                        {
                                                            TeacherId = g.Key,
                                                            TotalSalary = g.Sum(x => x.c.Salary),
                                                            FirstName = g.Min(x => x.t.FirstName),
                                                            LastName = g.Min(x => x.t.LastName),
                                                            Birthday = g.Min(x => x.t.Birthday),
                                                            Address = g.Min(x => x.t.Address),
                                                            Phone = g.Min(x => x.t.Phone),
                                                            Email = g.Min(x => x.t.Email)

                                                            //TeacherId = g.Key,
                                                            //TotalSalary = g.Sum(x => x.c.Salary),
                                                            //FirstName = g.First().t.FirstName,
                                                            //LastName = g.First().t.LastName,
                                                            //Birthday = g.First().t.Birthday,
                                                            //Address = g.First().t.Address,
                                                            //Phone = g.First().t.Phone,
                                                            //Email = g.First().t.Email
                                                        });

            return query.ToList();
        }
    }
}
