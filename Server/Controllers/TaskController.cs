using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Radigate.Server.Services.TaskService;

namespace Radigate.Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService) {
            _taskService = taskService;
        }
        [HttpGet("{patientId}")]
        public async Task<ActionResult<ServiceResponse<TaskItem>>> GetTask(int taskId) {
            var result = await _taskService.GetTask(taskId);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdateTask(TaskValueItem taskValue) {
            var result = await _taskService.SetTask(taskValue);
            return Ok(result);
        }
    }
}
