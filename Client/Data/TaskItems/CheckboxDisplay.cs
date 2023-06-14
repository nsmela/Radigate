﻿using MudBlazor;

namespace Radigate.Client.Data.TaskItems {
    public class CheckboxDisplay : ITaskItem {
        public Radigate.Shared.GroupDisplay TaskGroup { get; set; }
        public int Id { get; set; }
        public string Label { get; set; }
        public string Comments { get; set; }
        public string Value {
            get => IsChecked ? "true" : "false";
            set => IsChecked = value == "true";
        }

        public TaskType Type => TaskType.Bool;
        public string Icon => Icons.Material.Outlined.CheckBox;
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

        //non-inherited
        public bool IsChecked { get; set; } = false;

        public CheckboxDisplay(TaskItem task) {
            this.TaskGroup = task.TaskGroup;
            this.Id =task.Id;
            this.Label = task.Label;
            this.Comments = task.Comments;
            this.Value = task.Value;
        }
    }
}