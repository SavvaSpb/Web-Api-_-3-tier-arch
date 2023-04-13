using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public interface IUserAccountRepository
    {
        public List<UserAccount> Get();
        public UserAccount GetByLoginParameters(string email, string password);
    }

    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        private readonly MyContext context;

        public UserAccountRepository(MyContext context)
        {
            this.context = context;
        }
        public override int Add(UserAccount userAccount)
        {
            context.UserAccount.Add(userAccount);
            context.SaveChanges();

            return userAccount.UserAccountId;
        }

        public override List<UserAccount> Get()
        {
            List<UserAccount> userAccountGet = new List<UserAccount>();

            userAccountGet = context.UserAccount
                .AsNoTracking()
                .ToList();

            return userAccountGet;
        }

        public UserAccount GetByLoginParameters(string email, string password)
        {
            return context.UserAccount.FirstOrDefault(X => X.Email == email && X.Password == password);
        }

        public override UserAccount GetById(int id)
        {
            UserAccount userAccount = new UserAccount();

            userAccount = context.UserAccount
                .AsNoTracking()
                .FirstOrDefault(x => x.UserAccountId == id);

            return userAccount;
        }

        public override void Update(int id, UserAccount item)
        {
            var entity = context.UserAccount.Find(id);
            if (entity == null)
                return;

            entity.Email = item.Email;
            entity.Password = item.Password;
            entity.Phone = item.Phone;

            context.SaveChanges();
        }
    }
}
