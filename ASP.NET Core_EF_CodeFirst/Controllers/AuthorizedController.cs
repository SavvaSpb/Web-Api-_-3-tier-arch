using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_EF_CodeFirst.Controllers
{
    [Authorize]
    public class AuthorizedController : ControllerBase
    { }
}
