using MudBlazor;
using System.Data;

namespace Radigate.Client.Data.TaskItems {
    public class FormulaDisplay : ITaskItem {
        public TaskGroup TaskGroup { get; set; }
        public int? Id { get; set; } = null;
        public int SortOrder { get; set; }
        public string Label { get; set; }
        public string Comments { get; set; }
        public string Value { get; set; }

        public TaskType Type => TaskType.Calculation;
        public string Icon => Icons.Material.Filled.Calculate;
        public Patient Patient => TaskGroup.Patient;
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
        public ITaskItem Copy() => new FormulaDisplay {
            Id = this.Id,
            Label = this.Label,
            Comments = this.Comments,
            SortOrder = this.SortOrder,
            TaskGroup = this.TaskGroup,
            Value = this.Value
        };

        //non-inherited
        public FormulaDisplay() { }
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

        public string Calculate() {
            var cells = new List<Tuple<string, double>>();
            var text = Value.ToString();

            foreach (var group in Patient.TaskGroups) {
                for (int i = 0; i < TaskGroup.Tasks.Count; i++) {
                    if (TaskGroup.Tasks.ElementAt(i).Type != (int)TaskType.Number) continue;
                    var number = new NumberDisplay(TaskGroup.Tasks.ElementAt(i));
                    var label = TaskGroup.Label.Replace(" ", "") + i;
                    text = text.Replace(label, number.NumberValue.ToString());
                }
            }

            var dt = new DataTable();
            return dt.Compute(text, "").ToString();


        }

    }
}
