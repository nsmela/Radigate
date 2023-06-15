namespace Radigate.Server.Models {
    public class TaskGroupModel {
        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public List<TaskItemModel> Tasks { get; set; } = new();
    }
}
