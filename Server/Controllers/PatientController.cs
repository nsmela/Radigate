using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Radigate.Server.Data;

namespace Radigate.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase {
        private readonly PatientDataContext _context;
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService) {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Patient>>>> GetPatient() {
            var result = await _patientService.GetPatientsAsync();
            return Ok(result);
        }
    }
}
