using ASP.NET_Core_EF_CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;


namespace ASP.NET_Core_EF_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        // GET: api/<TeacherController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public TeacherModel Get(int id)
        {
            return null;// TeacherService.GetTeacherById(id);
        }

        // POST api/<TeacherController>
        [HttpPost]
        public void Add([FromBody] string value)
        {
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
