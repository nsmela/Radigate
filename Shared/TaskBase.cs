using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Radigate.Shared {
    public abstract class TaskBase {
        public TaskGroup TaskGroups { get; set; } = null!;//parent
        public int TaskGroupId { get; set; }
        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;

    }

    public class TaskBool : TaskBase {
        public bool Value { get; set; } = false;
    }

    public class TaskText : TaskBase {
        public string Value { get; set; } = string.Empty;
    }

    public class TaskDouble : TaskBase {
        public double Value { get; set; } = 0.0f;
    }
}
