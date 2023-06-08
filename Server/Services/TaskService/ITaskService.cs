namespace Radigate.Server.Services.TaskService {
    public interface ITaskService {
        public Task<ServiceResponse<TaskItem>> GetTask(int taskId);
        public Task<ServiceResponse<bool>> SetTask(TaskValueItem taskValue);
    }
}
