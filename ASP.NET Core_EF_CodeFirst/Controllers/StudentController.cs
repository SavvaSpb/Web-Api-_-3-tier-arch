using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_EF_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public IEnumerable<StudentModel> Get()
        {
            return studentService.Get();
        }

        [HttpGet("{id}")]
        public StudentModel Get([FromRoute] int id)
        {
            return studentService.GetStudentById(id);
        }

        [HttpPost]
        public void Add([FromBody] StudentModel student)
        {
            studentService.AddStudent(student);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] StudentModel student)
        {
            studentService.Update(id, student);
        }
    }
}
