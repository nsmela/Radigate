using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Radigate.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase {

        [HttpGet]
        public async Task<ActionResult<List<Patient>>> GetPatient() {
            return Ok();
        }
    }
}
