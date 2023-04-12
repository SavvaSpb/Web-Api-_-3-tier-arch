using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BLL.AuthHelpers
{
    public static class AuthOptions
    {
        public static SymmetricSecurityKey GetSymmetricSecurityKey(string key) =>
          new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    }
}
