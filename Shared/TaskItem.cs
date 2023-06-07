using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Radigate.Shared {
    public class TaskItem {
        [JsonIgnore] public TaskGroup TaskGroup { get; set; } = null!;//parent
        public int TaskGroupId { get; set; }
        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public int Type { get; init; }
        public string Value { get; set; } = string.Empty;
    }
}
