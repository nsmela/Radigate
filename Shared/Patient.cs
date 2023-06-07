using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radigate.Shared {
    public class Patient {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ICollection<TaskGroup> TaskGroups { get; set; } = new List<TaskGroup>(); //dependants
    }
}
