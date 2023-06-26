using MudBlazor;

namespace Radigate.Client.Data.TaskItems {
    public class CheckboxDisplay : ITaskItem {
        public TaskGroup TaskGroup { get; set; }
        public int? Id { get; set; } = null;
        public int SortOrder { get; set; }
        public string Label { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string Value {
            get => IsChecked ? "true" : "false";
            set => IsChecked = value == "true";
        }

        public TaskType Type => TaskType.Bool;
        public string Icon => Icons.Material.Outlined.CheckBox;
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
        public ITaskItem Copy() => new CheckboxDisplay {
            Id = this.Id, 
            Label = this.Label, 
            Comments = this.Comments, 
            SortOrder = this.SortOrder,
            TaskGroup = this.TaskGroup,
            Value = this.Value
        };

        //non-inherited
        public bool IsChecked { get; set; } = false;
        public CheckboxDisplay(string label) {
            this.Label = label;
            Value = "false";
        }

        public CheckboxDisplay() {
            this.Label = "new Task";
            this.IsChecked = false;
        }

        public CheckboxDisplay(TaskItem task) {
            this.TaskGroup = task.TaskGroup;
            this.Id = task.Id;
            this.Label = task.Label;
            this.Comments = task.Comments;
            this.Value = task.Value;
        }

    }
}
