using Radigate.Client.Data.TaskItems;

namespace Radigate.Client.Data {
    public class GroupDisplay {
        public Patient Parent { get; init; }
        public int PatientId => Parent.Id;
        public List<ITaskItem> Tasks { get; set; }

        public int Id { get; set; }
        public int SortingOrder { get; set; }
        public string Label { get; set; }
    }
}
