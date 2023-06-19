using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Radigate.Server.Data;
using Radigate.Shared;

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
        public async Task<ActionResult<ServiceResponse<List<Patient>>>> GetPatients() {
            var result = await _patientService.GetPatientsAsync();
            return Ok(result);
        }

        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Patient>>>> AdminGetPatients() {
            var result = await _patientService.AdminGetPatientsAsync();
            return Ok(result);
        }

        [HttpGet("{patientId}")]
        public async Task<ActionResult<ServiceResponse<List<Patient>>>> GetPatient(int patientId) {
            var result = await _patientService.GetPatientAsync(patientId);
            return Ok(result);
        }

        [HttpGet("ids")]
        public async Task<ActionResult<ServiceResponse<List<int>>>> GetPatientsId() {
            var result = await _patientService.GetPatientsIdAsync();
            return Ok(result);
        }

        [HttpGet("admin/ids"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<int>>>> AdminGetPatientsId() {
            var result = await _patientService.AdminGetPatientsIdAsync();
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdatePatient(PatientValueItem patient) {
            var result = await _patientService.UpdatePatientAsync(patient); 
            return Ok(result);
        }

        [HttpDelete("admin"), Authorize("Admin")]
        public async Task<ActionResult<ServiceResponse<List<Patient>>>> DeletePatient(int patientId) {
            var result = await _patientService.DeletePatient(patientId);
            return Ok(result);
        }

        [HttpPost("admin"), Authorize("Admin")]
        public async Task<ActionResult<ServiceResponse<List<Patient>>>> AddPatient(Patient patient) {
            var result = await _patientService.AddPatient(patient);
            return Ok(result);
        }
    }
}
