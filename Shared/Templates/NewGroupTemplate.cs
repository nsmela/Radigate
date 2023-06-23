using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radigate.Shared.Templates {
    public class NewGroupTemplate {
        [Required] public string Label { get; set; } = "New Group Template";
        public string Tasks { get; set; } = string.Empty;
        public bool IsPublic { get; set; } = false;

        public List<Tuple<string, int>> TaskList() {
            var tasks = Tasks.Split(';');

            var list = new List<Tuple<string, int>>();
            foreach (var task in tasks) {
                var item = task.Split(',');
                list.Add(new Tuple<string, int>(item[0], int.Parse(item[1])));
            }
            return list;
        }

        public static string TasksToString(List<Tuple<string, int>> list) {
            var text = string.Empty;
            foreach(var item in list) {
                text += item.Item1 + "," + item.Item2.ToString() + ";";
            }
            return text;
        }
    }
}
