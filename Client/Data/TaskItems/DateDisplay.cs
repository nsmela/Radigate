using MudBlazor;

namespace Radigate.Client.Data.TaskItems {
    public class DateDisplay : ITaskItem {
        public TaskGroup TaskGroup { get; set; }
        public int? Id { get; set; } = null;
        public int SortOrder { get; set; }
        public string Label { get; set; }
        public string Comments { get; set; }
        public string Value {
            get => DateValue.Value.ToShortDateString();
            set {
                DateTime date;
                if (DateTime.TryParse(value, out date)) DateValue = date;
            }
        }

        public TaskType Type => TaskType.Date;
        public string Icon => Icons.Material.Filled.CalendarMonth;
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
        public ITaskItem Copy() => new DateDisplay {
            Id = this.Id,
            Label = this.Label,
            Comments = this.Comments,
            SortOrder = this.SortOrder,
            TaskGroup = this.TaskGroup,
            Value = this.Value
        };

        //non-inherited
        public DateTime? DateValue { get; set; } = DateTime.Today;
        public DateDisplay() { }
        public DateDisplay(string label) {
            Label = label;
            DateValue = DateTime.Today;
        }
        public DateDisplay(TaskItem task) {
            this.TaskGroup = task.TaskGroup;
            this.Id = task.Id;
            this.Label = task.Label;
            this.Comments = task.Comments;
            this.Value = task.Value;
        }

    }
}
