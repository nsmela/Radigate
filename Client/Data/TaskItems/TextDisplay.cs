﻿using MudBlazor;

namespace Radigate.Client.Data.TaskItems {
    public class TextDisplay : ITaskItem {
        public TaskGroup TaskGroup { get; set; }
        public int? Id { get; set; } = null;
        public int SortOrder { get; set; }
        public string Label { get; set; }
        public string Comments { get; set; }
        public string Value { get; set; }

        public TaskType Type => TaskType.Text;
        public string Icon => Icons.Material.Filled.TextSnippet;
        public TaskItem ToTaskItem() {
                return new TaskItem {
                    Id = Id,
                    Label = Label,
                    Comments = Comments,
                    Value = Value,
                    Type = (int)this.Type,
                    TaskGroupId = this.TaskGroup.Id,
                };
            }

        public ITaskItem Copy() => new TextDisplay {
            Id = this.Id,
            Label = this.Label,
            Comments = this.Comments,
            SortOrder = this.SortOrder,
            TaskGroup = this.TaskGroup,
            Value = this.Value
        };

        //non-inherited
        public TextDisplay() { }
        public TextDisplay(string label) {
            Label = label;
            Value = string.Empty;
        }
        public TextDisplay(TaskItem task) {
            this.TaskGroup = task.TaskGroup;
            this.Id = task.Id;
            this.Label = task.Label;
            this.Comments = task.Comments;
            this.Value = task.Value;
        }
    }
}

