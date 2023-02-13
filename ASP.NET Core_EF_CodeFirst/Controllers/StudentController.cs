using ASP.NET_Core_EF_CodeFirst.Models;
using BLL.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_EF_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public StudentModel Get(int id)
        {
            return StudentService.GetById(id);
        }

        [HttpPost]
        public void Add([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
