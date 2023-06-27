namespace Radigate.Shared.Templates {
    public class PatientTemplate {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Label { get; set; } = "New Patient";
        public List<GroupTemplate> GroupTemplates { get; set; } = new();

        public PatientTemplate() {
            this.Label = "New Patient Template";
            this.GroupTemplates = new List<GroupTemplate>();
            this.Id = -1;
        }
        public PatientTemplate(NewPatientTemplate template) {
            this.Label = template.Label;
            GroupTemplates = new();
            foreach(var group in template.Groups) GroupTemplates.Add(group);
        }

        public void Update(PatientTemplate template) {
            this.Label = template.Label;
            this.GroupTemplates = template.GroupTemplates;
        }
    }
}
