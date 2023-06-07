using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped]
        public bool IsTrue {
            get => Value == "true";
            set => Value = value ? "true" : "false";
        }
        //combo box values are a concatentated list starting with the index of the selection and seperated by commas
        [NotMapped]
        public List<string> Options {
            get => Value.Split(',').Skip(1).ToList(); //the first value is an int, the index selected
            set {
                var options = SelectedOption.ToString();
                foreach(var option in value) options = options + "," + option;
                Value = options;
            }
        }

        [NotMapped] public int SelectedOption => Type == (int)TaskType.List ? int.Parse(Value.Split(',').First()) : -1;
        [NotMapped] public double Number => Type == (int)TaskType.Number ? double.Parse(Value) : 0.0f;
        [NotMapped] public DateTime Date => Type == (int)TaskType.Date ? DateTime.Parse(Value) : DateTime.MinValue;
        [NotMapped] public string Formula => Value;
    }
}
