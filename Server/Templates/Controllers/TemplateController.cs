using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Radigate.Server.Templates.Data;

namespace Radigate.Server.Templates.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase {
        private readonly ITemplateService _templateService;

        public TemplateController(ITemplateService templateService) {
            _templateService = templateService;
        }

        [HttpGet("groups"), Authorize(Roles = CustomRoles.Admin)]
        public async Task<ActionResult<ServiceResponse<List<GroupTemplate>>>> GetAllGroupTemplatesAsync() {
            var result = await _templateService.GetAllGroupTemplatesAsync();
            return Ok(result);
        }

        [HttpGet("patients"), Authorize(Roles = CustomRoles.Admin)]
        public async Task<ActionResult<ServiceResponse<List<PatientTemplate>>>> GetAllPatientTemplatesAsync() {
            var result = await _templateService.GetAllPatientTemplatesAsync();
            return Ok(result);
        }

        [HttpPost("groups"), Authorize(Roles = CustomRoles.Admin)]
        public async Task<ActionResult<ServiceResponse<bool>>> AddGroupTemplate(NewGroupTemplate template) {
            var result = await _templateService.AddGroupTemplateAsync(template);
            return Ok(result);
        }

        [HttpPost("patients"), Authorize(Roles = CustomRoles.Admin)]
        public async Task<ActionResult<ServiceResponse<bool>>> AddPatientTemplate(NewPatientTemplate template) {
            var result = await _templateService.AddPatientTemplateAsync(template);
            return Ok(result);
        }

        [HttpPut("groups"), Authorize(Roles = CustomRoles.Admin)]
        public async Task<ActionResult<ServiceResponse<GroupTemplate>>> UpdateGroupTemplate(GroupTemplate template) {
            var result = await _templateService.UpdateGroupTemplate(template);
            return Ok(result);
        }

        [HttpPut("patients"), Authorize(Roles = CustomRoles.Admin)]
        public async Task<ActionResult<ServiceResponse<PatientTemplate>>> UpdatePatientTemplate(PatientTemplate template) {
            var result = await _templateService.UpdatePatientTemplate(template);
            return Ok(result);
        }

        [HttpDelete("groups/{templateId}"), Authorize(Roles = CustomRoles.Admin)]
        public async Task<ActionResult<ServiceResponse<bool>>> RemoveGroupTemplate(int templateId) {
            var result = _templateService.RemoveGroupTemplateAsync(templateId);
            return Ok(result);
        }

        [HttpDelete("patients/{templateId}"), Authorize(Roles = CustomRoles.Admin)]
        public async Task<ActionResult<ServiceResponse<bool>>> RemovePatientTemplate(int templateId) {
            var result = _templateService.RemovePatientTemplateAsync(templateId);
            return Ok(result);
        }
    }
}
