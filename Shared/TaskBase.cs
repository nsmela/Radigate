using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Radigate.Shared {
    public enum TaskType { Bool, Text, Number, List, Date, Calculation, Base }

    public class TaskBase {
        [JsonIgnore] public TaskGroup TaskGroup { get; set; } = null!;//parent
        public int TaskGroupId { get; set; }
        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public int Type { get; init; }

    }

    public class TaskBool : TaskBase {
        public bool Check { get; set; } = false;
        public int Type => (int)TaskType.Bool;
        public TaskBool() { }
        
    }

    public class TaskText : TaskBase {
        public string Text { get; set; } = string.Empty;
        [JsonConstructor]
        public TaskText(int id, string label, string comments, string text) {
            Id = id;
            Label = label;
            Comments = comments;
            Text = text;
        }
    }

    public class TaskDouble : TaskBase {
        public double Number { get; set; } = 0.0f;
        [JsonConstructor]
        public TaskDouble(int id, string label, string comments, double number) {
            Id = id;
            Label = label;
            Comments = comments;
            Number = number;
        }
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
