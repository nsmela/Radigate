using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Radigate.Shared {
    public class TaskGroup {
        //parent
        [JsonIgnore] public Patient Patient { get; set; } = null!;
        public int PatientId { get; set; }

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>(); //dependants

        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;

    }
}
