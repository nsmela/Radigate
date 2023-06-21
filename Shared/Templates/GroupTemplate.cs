namespace Radigate.Shared.Templates {
    public class GroupTemplate {
        public int Id { get;set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Label { get; set;} = "New Group";
        public string Tasks { get; set; } = "NewTask,0;"; //tasks saved as "{label},{Type};"

        //relational
        public List<PatientTemplate> PatientTemplates { get; set; } = new();

        //constructors
        public GroupTemplate() {}
        public GroupTemplate(NewGroupTemplate group) {
            this.Label = group.Label;
            this.Tasks = group.Tasks;
        }
    }
}
