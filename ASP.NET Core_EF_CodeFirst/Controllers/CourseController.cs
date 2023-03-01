using ASP.NET_Core_EF_CodeFirst.Extensions.MappingExtensions;
using ASP.NET_Core_EF_CodeFirst.Models;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_EF_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;
        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public IEnumerable<CourseModel> Get()
        {
            return courseService.Get();
        }

        [HttpGet("{id}")]
        public CourseModel Get([FromRoute] int id)
        {
            return courseService.GetCourseById(id);
        }

        [HttpPost]
        public void Add([FromBody] CourseModel course)
        {
           courseService.AddCourse(course);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] CourseUpdateModel courseUpdateModel)
        {
            var courseModel = courseUpdateModel.MapToBusinessModel();
            courseService.Update(id, courseModel);
        }
    }
}
