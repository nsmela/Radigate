using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Radigate.Shared {
    public class TaskGroup {
        [JsonIgnore] public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;
        [JsonIgnore] public List<TaskBase> Tasks { get; set; } = new();
        public List<int> TaskIds { get; set; } = new();

    }
}
