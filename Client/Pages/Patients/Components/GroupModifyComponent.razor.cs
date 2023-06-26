using Microsoft.AspNetCore.Components;
using Radigate.Shared;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static MudBlazor.Colors;

namespace Radigate.Client.Pages.Patients.Components
{
    public partial class GroupModifyComponent : ComponentBase
    {

        #region Private Variables and Constants
        #endregion

        #region Inject Properties
        #endregion

        #region Parameter Properties
        [Parameter]
        public GroupDisplay? GroupDisplay { get; set; } = default!;
        #endregion

        #region Public Methods and Properties
        #endregion

        #region Internal and Protected Methods/Properties
        protected override async Task OnParametersSetAsync() {
            if (GroupDisplay is null) return;

            Group = new TaskGroupModifier { GroupDisplay = this.GroupDisplay, Tasks = new(), NewLabel = this.GroupDisplay.Label };
            foreach (var task in GroupDisplay.Tasks) {
                Group.Tasks.Add(new TaskItemModifier { Task = task, Parent = Group, NewLabel = task.Label });
            }
        }

        #endregion

        #region Private Methods/Properties
        private TaskGroupModifier? Group { get; set; } = default!;

        private void AddTaskItem(TaskGroupModifier group) { }
        private void OnTextFieldChangedHandler() { }

        private void DeleteGroup() { }
        private void EditGroupName() { }
        private void ChangeTaskType(TaskItemModifier task, TaskType type) { }
        private void EditTaskName(TaskItemModifier task) { }
        private void EditTask(TaskItemModifier task) { }
        private void RaiseTask(TaskItemModifier task) { }
        private void LowerTask(TaskItemModifier task) { }
        private void DeleteTask(TaskGroupModifier group, TaskItemModifier task) { }
        private void RemoveTaskListItem(ListDisplay task, string option) { }
        private void EditTaskListLabel(TaskItemModifier task, string option, string value) { }
        private void AddTaskListItem(TaskItemModifier task) { }
        private async Task OnTaskUpdated(ITaskItem task) {

        }

        #endregion

        internal class TaskGroupModifier {
            public bool Edit { get; set; } = false;
            public bool EditName { get; set; } = false;
            public bool IsNewTaskOpen { get; set; } = false;
            public string NewTaskLabel { get; set; } = string.Empty;
            public TaskType NewTaskType { get; set; } = default!;
            public string NewLabel { get; set; } = string.Empty;
            public GroupDisplay? GroupDisplay { get; set; } 
            public List<ITaskItem> Tasks { get; set; }
            public string Label => GroupDisplay is null ? string.Empty : GroupDisplay.Label;
            public string NewTaskIcon => (GroupDisplay.Convert(new TaskItem { Type = (int)NewTaskType })).Icon;
        }


    }
}