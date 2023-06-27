using System.Text.Json.Serialization;

namespace Radigate.Shared.Templates {
    public class GroupTemplate {
        public int Id { get;set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Label { get; set;} = "New Group";
        public string Tasks { get; set; } = "NewTask,0;"; //tasks saved as "{label},{Type};"
        public bool Public { get; set; } = false;

        //relational
        [JsonIgnore]
        public List<PatientTemplate> PatientTemplates { get; set; } = new();

        //constructors
        public GroupTemplate() {}
        public GroupTemplate(NewGroupTemplate newGroup) {
            this.Label = newGroup.Label;
            this.Tasks = newGroup.Tasks;
            this.Public = newGroup.IsPublic;
        }
        public GroupTemplate(GroupTemplate group) {
            this.Label = group.Label;
            this.Tasks = group.Tasks;
            this.Public = group.Public;
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

        public void Update(GroupTemplate group) {
            this.Label = group.Label;
            this.Tasks = group.Tasks;
            this.Public= group.Public;
        }
    }
}
