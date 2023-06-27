using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Radigate.Server.Data;
using Radigate.Server.Users;
using Radigate.Shared;

namespace Radigate.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService) {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Patient>>>> GetPatients() {
            var result = await _patientService.GetPatientsAsync();
            return Ok(result);
        }

        [HttpGet("admin"), Authorize(Roles = CustomRoles.Admin)]
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

        [HttpGet("admin/ids"), Authorize(Roles = CustomRoles.Admin)]
        public async Task<ActionResult<ServiceResponse<List<int>>>> AdminGetPatientsId() {
            var result = await _patientService.AdminGetPatientsIdAsync();
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdatePatient(PatientValueItem patient) {
            var result = await _patientService.UpdatePatientAsync(patient); 
            return Ok(result);
        }

        [HttpPut("archive")]
        public async Task<ActionResult<ServiceResponse<List<Patient>>>> ArchivePatient(int patientId, bool archive) {
            var result = await _patientService.ArchivePatient(patientId, archive);
            return Ok(result);
        }

        [HttpDelete("{patientId}"), Authorize(Roles = CustomRoles.Admin)]
        public async Task<ActionResult<ServiceResponse<List<Patient>>>> DeletePatient(int patientId) {
            var result = await _patientService.DeletePatient(patientId);
            return Ok(result);
        }

        [HttpPost, Authorize(Roles = CustomRoles.Admin)]
        public async Task<ActionResult<ServiceResponse<Patient>>> AddPatient(NewPatient patient) {
            var result = await _patientService.AddPatient(patient);
            return Ok(result);
        }
    }
}
