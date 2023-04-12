using ASP.NET_Core_EF_CodeFirst.Models;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Core_EF_CodeFirst.Extensions.MappingExtensions;
using Microsoft.AspNetCore.Authorization;

namespace ASP.NET_Core_EF_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<TeacherModel> Get()
        {
            return teacherService.Get();
        }

        [Authorize]
        [HttpGet("{id}")]
        public TeacherModel Get([FromRoute] int id)
        {
            return teacherService.GetTeacherById(id);
        }

        [Authorize]
        [HttpPost]
        public void Add([FromBody] TeacherModel teacher)
        {
            teacherService.AddTeacher(teacher);
        }

        [Authorize]
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] TeacherModel teacher)
        {
            teacherService.Update(id, teacher);
        }

        [Authorize]
        [HttpGet]
        [Route("with-salary")]
        public IEnumerable<TeacherWithSalaryModel> GetWithSalary()
        {
            var a = teacherService.GetWithSalary();
            return a.Select(x => x.MapToTeacherWithSalaryDto());
        }
    }
}

