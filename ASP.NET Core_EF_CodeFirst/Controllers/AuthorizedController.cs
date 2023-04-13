using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_EF_CodeFirst.Controllers
{
    [Authorize]
    public abstract class AuthorizedController : ControllerBase
    { }
}
