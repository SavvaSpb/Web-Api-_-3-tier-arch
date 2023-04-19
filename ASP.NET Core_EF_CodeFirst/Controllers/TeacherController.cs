using ASP.NET_Core_EF_CodeFirst.Models;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Core_EF_CodeFirst.Extensions.MappingExtensions;

namespace ASP.NET_Core_EF_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : AuthorizedController
    {
        private readonly ITeacherService teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [HttpGet]
        public IEnumerable<TeacherModel> Get()
        {
            return teacherService.Get();
        }

        [HttpGet("{id}")]
        public TeacherModel Get([FromRoute] int id)
        {
            return teacherService.GetTeacherById(id);
        }

        [HttpPost]
        public void Add([FromBody] TeacherModel teacher)
        {
            teacherService.AddTeacher(teacher);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] TeacherModel teacher)
        {
            teacherService.Update(id, teacher);
        }

        [HttpGet]
        [Route("with-salary")]
        public IEnumerable<TeacherWithSalaryModel> GetWithSalary()
        {
            var a = teacherService.GetWithSalary();
            return a.Select(x => x.MapToTeacherWithSalaryDto());
        }
    }
}

