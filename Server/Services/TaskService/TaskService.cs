using Radigate.Server.Data;

namespace Radigate.Server.Services.TaskService {
    public class TaskService : ITaskService {
        private readonly PatientDataContext _context;

        public TaskService(PatientDataContext context) {
            _context = context;
        }
        public async Task<ServiceResponse<TaskItem>> GetTask(int taskId) {
            var task = await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == taskId);

            if (task is null) {
                return new ServiceResponse<TaskItem> {
                    Success = false,
                    Message = $"task does not exist! (Id:{taskId})"
                };
            }

            return new ServiceResponse<TaskItem> { Data = task };
        }

        public async Task<ServiceResponse<bool>> SetTask(TaskValueItem taskValue) {
            var sameTask = await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == taskValue.TaskId);

            if (sameTask is null) {
                return new ServiceResponse<bool> {
                    Data = false,
                    Success = false,
                    Message = $"task does not exist! (Id:{taskValue.TaskId}, Value:{taskValue.TaskValue})"
                };
            }

            sameTask.Value = taskValue.TaskValue;
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true};
        }
    }
}
