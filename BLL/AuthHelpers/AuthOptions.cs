using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BLL.AuthHelpers
{
    internal static class AuthOptions
    {
        internal static SymmetricSecurityKey GetSymmetricSecurityKey(string key) =>
          new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        internal static X509Certificate2 GetSymmetricSecurityKey()
        {
            throw new NotImplementedException();
        }
    }
}
