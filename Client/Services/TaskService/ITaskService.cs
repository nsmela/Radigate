namespace Radigate.Client.Services.TaskService {
    public interface ITaskService {
        public Task UpdateTaskValue(ITaskItem task, string value);
    }
}
