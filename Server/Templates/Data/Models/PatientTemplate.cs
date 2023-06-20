namespace Radigate.Server.Templates.Data.Models {
    public class PatientTemplate {
        public int Id { get; set; }
        public string Label { get; set; } = "New Patient";
        public List<GroupTemplate> GroupTemplates { get; set; } = new();
    }
}
