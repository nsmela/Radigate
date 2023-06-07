using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Radigate.Shared {
    public enum TaskType { Bool, Text, Number, List, Date, Calculation }

    public abstract class TaskBase {
        [JsonIgnore] public TaskGroup TaskGroup { get; set; } = null!;//parent
        public int TaskGroupId { get; set; }
        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public int TaskType { get; init; }

    }

    public class TaskBool : TaskBase {
        public bool Checked { get; set; } = false;
    }

    public class TaskText : TaskBase {
        public string Text { get; set; } = string.Empty;
    }

    public class TaskDouble : TaskBase {
        public double Number { get; set; } = 0.0f;
    }

    public class TaskList : TaskBase {
        public int SelectedValue { get; set; } = -1;
        public string Options { get; set; } = string.Empty;
        public List<string> OptionsList =>  Options.Split(',').ToList();
        public string Value => OptionsList[SelectedValue];
    }

    public class TaskDate : TaskBase {
        public DateTime? Date { get; set; } = DateTime.Today;
    }

    public class TaskCalculation : TaskBase {
        public string? Formula { get; set; } = string.Empty;
    }
}
