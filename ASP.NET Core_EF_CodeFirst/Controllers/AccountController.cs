using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using BLL.Models;
using ASP.NET_Core_EF_CodeFirst.Models;
using ASP.NET_Core_EF_CodeFirst.Extensions.MappingExtensions;

namespace ASP.NET_Core_EF_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserAccountService userAccountService;

        public AccountController(IUserAccountService userAccountService)
        {
            this.userAccountService = userAccountService;
        }

        [HttpPost]
        [Route("login")]
        public LoginResponseModel Login([FromBody] LoginRequestModel model)
        {
            UserAccountModel userModel = model.MapToBusinessModel();
            return userAccountService.Login(userModel);
        }
    }
}
