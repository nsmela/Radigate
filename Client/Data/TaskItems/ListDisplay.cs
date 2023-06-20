using MudBlazor;
using System.Threading.Tasks;

namespace Radigate.Client.Data.TaskItems {
    public class ListDisplay : ITaskItem {
        public TaskGroup TaskGroup { get; set; }
        public int? Id { get; set; } = null;
        public int SortOrder { get; set; }
        public string Label { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string Value {
            get {
                string text = Options.FindIndex(o => o == SelectedOption).ToString();
                Options.ForEach(o => text += "," + o);
                return text;
            }
            set {
                var options = value.Split(',').ToList();

                if (options.Count < 1) {
                    SelectedOption = "NO OPTIONS";
                    Options = new();
                    return;
                }

                int result = -1;
                int.TryParse(options[0], out result);
                options.RemoveAt(0);
                SelectedOption = options.Count > 0 && result >= 0 ? options[result] : "INVALID SELECTION";
                Options = options;
            }
        }

        public TaskType Type => TaskType.List;
        public string Icon => Icons.Material.Outlined.List;
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
        public List<string> Options { get; set; } = new();
        public string SelectedOption { get; set; } = string.Empty;
        public ListDisplay(string label) {
            Label = label;
            Options = new List<string> { "Option 1", "Option 2", "Option 3" };
            SelectedOption = Options[0];
        }
        public ListDisplay(TaskItem task) {
            this.TaskGroup = task.TaskGroup;
            this.Id = task.Id;
            this.Label = task.Label;
            this.Comments = task.Comments;
            this.Value = task.Value;
        }
    }
}