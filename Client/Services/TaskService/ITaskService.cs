namespace Radigate.Client.Services.TaskService {
    public interface ITaskService {
        public Task UpdateTaskValue(TaskItem task, string value);
    }
}
