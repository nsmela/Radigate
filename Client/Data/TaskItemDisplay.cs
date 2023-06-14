using System.Text.Json.Serialization;

namespace Radigate.Client.Data {
    public interface TaskItemDisplay {
        public TaskGroup TaskGroup { get; set; }
        public int TaskGroupId => TaskGroup.Id;
        public int Id { get; set; }
        public string Label { get; set; }
        public string Comments { get; set; } 
        public string Value { get; set; }

        public TaskItem ToTaskItem();
    }
}
