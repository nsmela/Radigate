namespace Radigate.Client.Data {
    public class PatientDisplay {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;

        public List<GroupDisplay> TaskGroups { get; set; } = new();
    }
}
