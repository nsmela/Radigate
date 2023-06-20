namespace Radigate.Server.Templates.Data.Models {
    public class GroupTemplate {
        public int Id { get;set;}
        public string Label { get; set;} = "New Group";
        public string Tasks { get; set; } = "NewTask,0;"; //tasks saved as "{label},{Type};"

        //relational
        public List<PatientTemplate> PatientTemplates { get; set; } = new();
    }
}
