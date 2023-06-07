using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Radigate.Shared {
    public enum TaskType { Bool, Text, Number, List, Date, Calculation, Base }

    public partial class TaskItem {
        [JsonIgnore] public TaskGroup TaskGroup { get; set; } = null!;//parent
        public int TaskGroupId { get; set; }
        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public int Type { get; init; }
        public string Value { get; set; } = string.Empty;
    }

    public partial class TaskItem {
        //need to remember these properties need to be bi-directional
        public bool IsTrue {
            get => Value == "true";
            set => Value = value ? "true" : "false";
        }
        //combo box values are a concatentated list starting with the index of the selection and seperated by commas
        public List<string> Options {
            get => Value.Split(',').Skip(1).ToList(); //the first value is an int, the index selected
            set {
                var options = SelectedOption.ToString();
                foreach(var option in value) options = options + "," + option;
                Value = options;
            }
        }
        public int SelectedOption => int.Parse(Value.Split(',').First());
        public double Number => double.Parse(Value);
        public DateTime Date => DateTime.Parse(Value);
        public string Formula => Value;
    }
}
