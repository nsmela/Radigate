using static MudBlazor.FilterOperator;
using System.Threading.Tasks;
using MudBlazor;

namespace Radigate.Client.Data.TaskItems {
    public class NumberDisplay : ITaskItem {
        public Radigate.Shared.TaskGroup TaskGroup { get; set; }
        public int Id { get; set; } = -1;
        public int SortOrder { get; set; }
        public string Label { get; set; }
        public string Comments { get; set; }
        public string Value {
            get => NumberValue.ToString();
            set {
                double number;
                if (double.TryParse(value, out number)) NumberValue = number;
            }
        }

        public TaskType Type => TaskType.Number;
        public string Icon => Icons.Material.Filled.Numbers;
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
        public double NumberValue { get; set; } = 0.0f;
        public NumberDisplay(string label) {
            Label = label;
            NumberValue = 0.0f;
        }
        public NumberDisplay(TaskItem task) {
            this.TaskGroup = task.TaskGroup;
            this.Id = task.Id;
            this.Label = task.Label;
            this.Comments = task.Comments;
            this.Value = task.Value;
        }
    }
}

