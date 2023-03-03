using ASP.NET_Core_EF_CodeFirst.Models;
using BLL.Models;

namespace ASP.NET_Core_EF_CodeFirst.Extensions.MappingExtensions
{
    public static class TeacherMappingExtensions
    {
        public static TeacherWithSalaryModel MapToTeacherWithSalaryDto(this TeacherModel mappingObject)
        {
            if (mappingObject == null)
                throw new ArgumentNullException(nameof(mappingObject));

            TeacherWithSalaryModel dest = new()
            {
                Id = mappingObject.Id,
                TotalSalary = mappingObject.TotalSalary,
                FirstName = mappingObject.FirstName,
                LastName = mappingObject.LastName,
                Birthday = mappingObject.Birthday,
                Address = mappingObject.Address,
                Phone = mappingObject.Phone,
                Email = mappingObject.Email

            };

            return dest;
        }
    }
}
