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
        public string Identifier { get; set; } = string.Empty;
        public ICollection<TaskGroup> TaskGroups { get; set; } = new List<TaskGroup>(); //navigation property

        public void Sort() {
            foreach(var group in TaskGroups) group.Tasks = group.Tasks.OrderBy(t => t.SortingOrder).ToList();
            TaskGroups = TaskGroups.OrderBy(g => g.SortingOrder).ToList();
        }
    }
}
