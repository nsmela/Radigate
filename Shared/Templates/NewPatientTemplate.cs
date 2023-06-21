using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radigate.Shared.Templates {
    public class NewPatientTemplate {
        //Data Transfer Object
        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public ICollection<GroupTemplate> Groups { get; set; }

    }
}
