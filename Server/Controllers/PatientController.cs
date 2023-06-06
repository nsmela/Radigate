using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Radigate.Server.Data;

namespace Radigate.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase {
        private readonly PatientDataContext _context;

        public PatientController(PatientDataContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Patient>>> GetPatient() {
            var patients = await _context.Patients.ToListAsync();
            return Ok(patients);
        }
    }
}
