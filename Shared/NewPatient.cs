using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radigate.Shared {
    public class NewPatient {
        [Required] public string FirstName { get; set; } = String.Empty;
        [Required] public string LastName { get; set; } = String.Empty;
        [Required] public string Identifier { get; set; } = String.Empty;

        [Required] public List<string> Groups { get; set; } = new();
        [Required] public List<NewTaskItem> Tasks { get; set; } = new(); 
    }

    public class NewTaskItem {
        [Required] public string Label { get; set; } = String.Empty;
        [Required] public TaskType Type { get; set; } = TaskType.Bool;
        [Required] public string Group { get; set; } = String.Empty;
        public string Value { get; set; } = string.Empty;

    }
}
