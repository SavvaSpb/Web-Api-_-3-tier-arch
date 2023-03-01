using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_EF_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstituteController : ControllerBase
    {
        private readonly IInstituteService instituteService;
        public InstituteController(IInstituteService instituteService)
        {
            this.instituteService = instituteService;
        }

        [HttpGet]
        public IEnumerable<InstituteModel> Get()
        {
            return instituteService.Get();
        }

        [HttpGet("{id}")]
        public InstituteModel Get([FromRoute] int id)
        {
            return instituteService.GetInstituteById(id);
        }

        [HttpPost]
        public void Add([FromBody] InstituteModel institute)
        {
            instituteService.AddInstitute(institute);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] InstituteModel institute)
        {
            instituteService.Update(id, institute);
        }
    }
}
