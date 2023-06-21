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

        //methods
        public List<Tuple<string, int>> TaskList() {
            var tasks = Tasks.Split(';');

            var list = new List<Tuple<string, int>>();
            foreach (var task in tasks) {
                var item = task.Split(',');
                if (item.Length != 2) continue;
                list.Add(new Tuple<string, int>(item[0], int.Parse(item[1])));
            }
            return list;
        }

        public static string TasksToString(List<Tuple<string, int>> list) {
            var text = string.Empty;
            foreach (var item in list) {
                text += TaskToString(item);
            }
            return text;
        }

        public static string TaskToString(Tuple<string, int> task) => task.Item1 + ',' + task.Item2 + ';';
    }
}
