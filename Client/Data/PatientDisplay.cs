﻿namespace Radigate.Client.Data {
    public class PatientDisplay {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;
        public bool Archived { get; set; } = false;

        public List<GroupDisplay> TaskGroups { get; set; } = new();

        public PatientDisplay() {

        }

        public PatientDisplay(Patient? patient) {
            if (patient is null) return;

            this.Id = patient.Id;
            this.FirstName = patient.FirstName;
            this.LastName = patient.LastName;
            this.Identifier = patient.Identifier;
            this.Archived = patient.Archived;

            TaskGroups = new();
            patient.TaskGroups.OrderBy(g => g.SortingOrder);
            foreach (var group in patient.TaskGroups) {
                group.Patient = patient;
                var newGroup = new GroupDisplay(group);

                newGroup.SortingOrder = TaskGroups.Count;
                TaskGroups.Add(newGroup);

            }

        }
    }
}
