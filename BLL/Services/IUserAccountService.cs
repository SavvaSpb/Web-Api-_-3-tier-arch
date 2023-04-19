using BLL.Models;

namespace BLL.Services
{
    public interface IUserAccountService
    {
        List<UserAccountModel> Get();
        LoginResponseModel Login(UserAccountModel model);
    }
}
