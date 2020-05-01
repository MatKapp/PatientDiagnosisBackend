using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PatientDiagnosis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await Task.FromResult("test"));
    }
}
