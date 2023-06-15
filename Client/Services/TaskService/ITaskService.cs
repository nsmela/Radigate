namespace Radigate.Client.Services.TaskService {
    public interface ITaskService {
        public Task UpdateTaskValue(int? taskId, string value);
    }
}
