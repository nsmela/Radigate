using Microsoft.Extensions.Options;

namespace Radigate.Client.Services.TaskService {
    public class TaskService : ITaskService {
        private readonly HttpClient _http;
        private readonly IPatientService _patientService;

        public TaskService(HttpClient http, IPatientService patientService) {
            _http = http;
            _patientService = patientService;
        }

        public async Task UpdateTaskValue(int? taskId, string value) {
            if (taskId == null) return;

            var taskValueItem = new TaskValueItem { TaskId = taskId.Value, TaskValue = value };

            var connection = $"/api/Task/update";
            await  _http.PutAsJsonAsync(connection, taskValueItem); //converts the subclass into the base class

            _patientService.UpdatePatientTask(taskId.Value);
        }
    }
}
