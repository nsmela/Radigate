using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Radigate.Shared {
    public enum TaskType { Bool, Text, Number, List, Date, Calculation, Base }

    public class TaskItem {
        [JsonIgnore] public TaskGroup TaskGroup { get; set; } = null!;//parent
        public int TaskGroupId { get; set; }
        public int SortingOrder { get; set; }
        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public int Type { get; set; }
        public string Value { get; set; } = string.Empty;

        public virtual TaskItem ToTaskItem() => this;

        public static TaskItem Convert(TaskItem task) {
            switch (task.Type) {
                case (int)TaskType.Bool:
                    return new TaskBool(task);
                case (int)TaskType.Text:
                    return new TaskText(task);
                case (int)TaskType.Number:
                    return new TaskNumber(task);
                case (int)TaskType.List:
                    return new TaskList(task);
                default:
                    return (TaskItem)task;
            }
        }
    }

    //Task classes
    public class TaskBool : TaskItem {
        public bool Checked { get; set; }
        public TaskBool(TaskItem task) {
            TaskGroup = task.TaskGroup;
            Id = task.Id;
            Label = task.Label;
            Comments = task.Comments;
            Type = task.Type;
            Value = task.Value;

            Checked = task.Value == "true";
        }
        public string ValueString => Value;
        public override TaskItem ToTaskItem() {
            return new TaskItem {
                Id = this.Id,
                Label = this.Label,
                Comments = this.Comments,
                Type = this.Type,
                TaskGroupId = this.TaskGroup.Id,
                Value = Checked ? "true" : "false"
            };
        }
    }

    public class TaskText : TaskItem {
        public string Text { get; set; }
        public TaskText(TaskItem task) {
            TaskGroup = task.TaskGroup;
            Id = task.Id;
            Label = task.Label;
            Comments = task.Comments;
            Type = task.Type;
            Value = task.Value;

            Text = task.Value;
        }
        public string ValueString => Text;
        public override TaskItem ToTaskItem() {
            return new TaskItem {
                Id = this.Id,
                Label = this.Label,
                Comments = this.Comments,
                Type = this.Type,
                TaskGroupId = this.TaskGroup.Id,
                TaskGroup = this.TaskGroup,
                Value = Text
            };
        }
    }

    public class TaskNumber : TaskItem {
        public double Number { get; set; } = 0.0f;
        public TaskNumber(TaskItem task) {
            TaskGroup = task.TaskGroup;
            Id = task.Id;
            Label = task.Label;
            Comments = task.Comments;
            Type = task.Type;
            Value = task.Value;

            double number;
            if (double.TryParse(task.Value, out number)) Number = number;
        }
        public string ValueString => Value;
        public override TaskItem ToTaskItem() {
            return new TaskItem {
                Id = this.Id,
                Label = this.Label,
                Comments = this.Comments,
                Type = this.Type,
                TaskGroupId = this.TaskGroup.Id,
                Value = Number.ToString()
            };
        }
    }

    public class TaskList : TaskItem {
        public List<string> Options { get; set; } = new List<string>();
        public string SelectedOption { get; set; } = "No selection";
        public TaskList(TaskItem task) {
            TaskGroup = task.TaskGroup;
            Id = task.Id;
            Label = task.Label;
            Comments = task.Comments;
            Type = task.Type;

            if (string.IsNullOrEmpty(task.Value)) return;

            var options = task.Value.Split(',').ToList();
            int result = -1;
            int.TryParse(options[0], out result);
            options.RemoveAt(0);
            SelectedOption = options[result];
            Options = options;

            Value = SelectedOption;
        }
        public string ValueString {
            get {
                var text = Options.IndexOf(SelectedOption).ToString();
                Options.ForEach(o => text += "," + o);
                return text;
            }
        }
        public override TaskItem ToTaskItem() {
            var text = Options.IndexOf(SelectedOption).ToString();
            Options.ForEach(o => text += "," + o);

            return new TaskItem {
                Id = this.Id,
                Label = this.Label,
                Comments = this.Comments,
                Type = this.Type,
                TaskGroupId = this.TaskGroup.Id,
                Value = text
            };
        }
    }

    public class TaskDate : TaskItem {
        public DateTime? Date { get; set; } = new DateTime();
        public TaskDate(TaskItem task) {
            TaskGroup = task.TaskGroup;
            Id = task.Id;
            Label = task.Label;
            Comments = task.Comments;
            Type = task.Type;

            if (string.IsNullOrEmpty(task.Value)) return;

            var date = new DateTime();
            if (DateTime.TryParse(task.Value, out date)) Date = date;

        }
        public string ValueString => Date is null ? null : Date.Value.ToShortDateString();
        public override TaskItem ToTaskItem() {
            return new TaskItem {
                Id = this.Id,
                Label = this.Label,
                Comments = this.Comments,
                Type = this.Type,
                TaskGroupId = this.TaskGroup.Id,
                Value = Date is null ? null : Date.Value.ToShortDateString()
            };
        }
    }

    public class TaskCalculate : TaskItem {
        public string Formula { get; set; } = "no formula";
        public TaskCalculate(TaskItem task) {
            TaskGroup = task.TaskGroup;
            Id = task.Id;
            Label = task.Label;
            Comments = task.Comments;
            Type = task.Type;
            Value = task.Value;

            Formula = task.Value;
        }
        public string ValueString => Formula;
        public override TaskItem ToTaskItem() {
            return new TaskItem {
                Id = this.Id,
                Label = this.Label,
                Comments = this.Comments,
                Type = this.Type,
                TaskGroupId = this.TaskGroup.Id,
                Value = Formula
            };
        }
    }
}