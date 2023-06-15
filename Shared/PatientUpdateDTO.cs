using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radigate.Shared {
    public class PatientUpdateDTO {
        public int? PatientId { get; set; } = null;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;
        public List<TaskGroupDTO> Groups { get; set; } = new();
    }

    public class TaskGroupDTO {
        public int? Id { get; set; } = null;
        public bool IsDeleted { get; set; } = false;
        public string Label { get; set; } = string.Empty;
        public List<TaskItemDTO> Tasks { get; set; } = new();
    }

    public class TaskItemDTO {
        public int? Id { get; set; } = null;
        public bool IsDeleted { get; set; } = false;
        public string Label { get; set; } = string.Empty;
        public TaskType Type { get; set; }
        public string Comments { get; set; } = string.Empty;
    }
}
