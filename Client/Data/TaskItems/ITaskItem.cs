using MudBlazor;
using System.Threading.Tasks;

namespace Radigate.Client.Data.TaskItems {
    public interface ITaskItem {
        public TaskGroup TaskGroup { get; set; }
        public int TaskGroupId => TaskGroup.Id;
        public int? Id { get; set; }
        public int SortOrder { get; set; }
        public string Icon { get; }
        public TaskType Type { get; }
        public string Label { get; set; }
        public string Comments { get; set; }
        public string Value { get; set; }

        public TaskItem ToTaskItem();
        public ITaskItem Copy();
    }

    public static class TaskTypeExtensions {
        public static string ToIcon(TaskType type) {
            switch (type) {
                case TaskType.Bool:
                    return Icons.Material.Outlined.CheckBox;
                case TaskType.Text:
                    return Icons.Material.Filled.TextSnippet;
                case TaskType.Number:
                    return Icons.Material.Filled.Numbers;
                case TaskType.List:
                    return Icons.Material.Outlined.List;
                case TaskType.Date:
                    return Icons.Material.Filled.CalendarMonth;
                case TaskType.Calculation:
                    return Icons.Material.Filled.Calculate;
                default:
                    return @Icons.Material.Filled.QuestionMark;
            }
        }

        public static string ToLabel(TaskType type) => Enum.GetName(typeof(TaskType), type);
        public static string ToLabel(int type) => Enum.GetName(typeof(TaskType), type);
    }
}
