namespace Radigate.Server.Models {
    public class PatientModel {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;
        public List<TaskGroupModel> TaskGroups { get; set; } = new();
    }
}
