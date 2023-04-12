using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public IEnumerable<InstituteModel> Get()
        {
            return instituteService.Get();
        }

        [Authorize]
        [HttpGet("{id}")]
        public InstituteModel Get([FromRoute] int id)
        {
            return instituteService.GetInstituteById(id);
        }

        [Authorize]
        [HttpPost]
        public void Add([FromBody] InstituteModel institute)
        {
            instituteService.AddInstitute(institute);
        }

        [Authorize]
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] InstituteModel institute)
        {
            instituteService.Update(id, institute);
        }
    }
}
