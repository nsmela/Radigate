using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radigate.Shared {
    public class PatientValueItem {
        public int PatientId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;
        public List<GroupValueItem> Groups { get; set; } = new();


        public class GroupValueItem {
            public int Id { get; set; }
            public string Label { get; set; } = string.Empty;
            public List<TaskItemValue> Tasks { get; set; } = new();
        }

        public class TaskItemValue {
            public int Id { get; set; }
            public string Label { get; set; } = string.Empty;
            public string Comments { get; set; } = string.Empty;
            public int Type { get; set; }
            public string Value { get; set; } = string.Empty;
        }
    }


}
