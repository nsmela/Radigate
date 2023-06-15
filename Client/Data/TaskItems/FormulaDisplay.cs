using MudBlazor;

namespace Radigate.Client.Data.TaskItems {
    public class FormulaDisplay : ITaskItem {
        public Radigate.Shared.TaskGroup TaskGroup { get; set; }
        public int? Id { get; set; } = null;
        public int SortOrder { get; set; }
        public string Label { get; set; }
        public string Comments { get; set; }
        public string Value { get; set; }

        public TaskType Type => TaskType.Calculation;
        public string Icon => Icons.Material.Filled.Calculate;
        public TaskItem ToTaskItem() {
            return new TaskItem {
                Id = Id,
                Label = Label,
                Comments = Comments,
                Value = Value,
                Type = (int)this.Type,
                TaskGroupId = this.TaskGroup.Id,
            };
        }

        //non-inherited
        public FormulaDisplay(string label) {
            Label = label;
            Value = string.Empty;
        }
        public FormulaDisplay(TaskItem task) {
            this.TaskGroup = task.TaskGroup;
            this.Id = task.Id;
            this.Label = task.Label;
            this.Comments = task.Comments;
            this.Value = task.Value;
        }
    }
}
