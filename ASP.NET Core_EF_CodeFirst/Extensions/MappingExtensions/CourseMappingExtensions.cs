using ASP.NET_Core_EF_CodeFirst.Models;
using BLL.Models;

namespace ASP.NET_Core_EF_CodeFirst.Extensions.MappingExtensions
{
    public static class CourseMappingExtensions
    {
        public static CourseModel MapToBusinessModel(this CourseUpdateModel? mappingObject)
        {
            if (mappingObject == null)
                throw new ArgumentNullException(nameof(mappingObject));

            return new CourseModel
            {
                TeacherId = mappingObject.TeacherId,
                Salary = mappingObject.Salary
            };
        }
    }
}
