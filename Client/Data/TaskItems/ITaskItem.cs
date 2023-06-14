﻿using MudBlazor;

namespace Radigate.Client.Data.TaskItems
{
    public interface ITaskItem
    {
        public Radigate.Shared.GroupDisplay TaskGroup { get; set; }
        public int TaskGroupId => TaskGroup.Id;
        public int Id { get; set; }
        public string Icon { get; }
        public TaskType Type { get; }
        public string Label { get; set; }
        public string Comments { get; set; }
        public string Value { get; set; }

        public TaskItem ToTaskItem();
    }
}
