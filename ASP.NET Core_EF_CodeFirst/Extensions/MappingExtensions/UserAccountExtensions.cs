using ASP.NET_Core_EF_CodeFirst.Models;
using BLL.Models;

namespace ASP.NET_Core_EF_CodeFirst.Extensions.MappingExtensions
{
    public static class UserAccountExtensions
    {
        public static UserAccountModel MapToBusinessModel(this LoginRequestModel mappingObject)
        {
            if (mappingObject == null)
                throw new ArgumentNullException(nameof(mappingObject));

            return new UserAccountModel
            {
                Email = mappingObject.Email,
                Password = mappingObject.Password
            };
        }
    }
}
