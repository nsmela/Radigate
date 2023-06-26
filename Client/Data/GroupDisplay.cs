using Radigate.Client.Data.TaskItems;

namespace Radigate.Client.Data {
    public class GroupDisplay {
        public Patient Parent { get; init; } = default!;
        public int PatientId { get; set; }
        public List<ITaskItem> Tasks { get; set; } = new();

        public int Id { get; set; } = -1;
        public int SortingOrder { get; set; }
        public string Label { get; set; }

        public GroupDisplay() {

        }

        public GroupDisplay(TaskGroup group) {
            this.Id = group.Id;
            this.SortingOrder = group.SortingOrder;
            this.Label = group.Label;
            this.PatientId = group.PatientId;

            Tasks = new();
            foreach (var task in group.Tasks) Tasks.Add(Convert(task));
        }

        public static ITaskItem Convert(TaskItem task) {
            switch (task.Type) {
                case (int)TaskType.Bool:
                    return new CheckboxDisplay(task);
                case (int)TaskType.Text:
                    return new TextDisplay(task);
                case (int)TaskType.Number:
                    return new NumberDisplay(task);
                case (int)TaskType.List:
                    return new ListDisplay(task);
                case (int)TaskType.Date:
                    return new DateDisplay(task);
                case (int)TaskType.Calculation:
                    return new FormulaDisplay(task);
                default:
                    return null;
            }
        }
    }
}
