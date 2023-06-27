using Microsoft.AspNetCore.Components;
using System.Reflection.Metadata;

namespace Radigate.Client.Pages.Patients.Components
{
    public partial class TaskModifyComponent : ComponentBase
    {
        #region Private Variables and Constants
        #endregion

        #region Inject Properties
        #endregion

        #region Parameter Properties
        [Parameter]
        public ITaskItem Task { get; set; } = new CheckboxDisplay();
        [Parameter]
        public bool Edit { get; set; } = false;
        [Parameter]
        public EventCallback<ITaskItem> TaskItemChanged { get; set; } = default!;
        [Parameter]
        public EventCallback<ITaskItem> EditModeChanged { get; set; } = default!;
        #endregion

        #region Public Methods and Properties
        #endregion

        #region Internal and Protected Methods/Properties
        protected override async Task OnParametersSetAsync() {
            TaskLabel = this.Task.Label;
            TaskItemType = this.Task.Type;
            SortOrder = this.Task.SortOrder;
        }

        #endregion

        #region Private Methods/Properties
        private string Icon => GroupDisplay.Convert(new TaskItem { Type = (int)TaskItemType }).Icon;
        private string TaskLabel { get; set; } = string.Empty;
        private TaskType TaskItemType { get; set; } = default!;
        private int SortOrder { get; set; } = default!;

        private async Task AddTaskListItem() { 
            var list = (ListDisplay)Task;
            list.Options.Add($"Option {list.Options.Count + 1}");
            //await UpdateParent();
        }

        private async Task ChangeTaskType(TaskType type) {
            TaskItemType = type;
            await UpdateParent();
        }
        private async Task DeleteTask() {
            this.Task.SortOrder = -1;
            await TaskItemChanged.InvokeAsync(Task);
        }

        //open or close the editing of the task
        private async Task EditTask() {
            if (Edit) await UpdateParent();
            else await EditModeChanged.InvokeAsync(this.Task);
        }

        private async void EditTaskListLabel(string originalValue, string value) {
            var list = (ListDisplay)Task;
            int index = list.Options.FindIndex(o => o == originalValue);
            list.Options[index] = value;
            await UpdateParent();
        }

        private async void EditTaskName() {
            if (this.TaskLabel == Task.Label) return; //no change
            Edit = false;
            await UpdateParent();

        }

        private async Task LowerTask() {
            SortOrder++;
            await UpdateParent();
        }

        private async Task RaiseTask() {
            if (SortOrder <= 0) return;

            SortOrder--;
            await UpdateParent();
        }

        private async void RemoveTaskListItem(string option) {
            var list = (ListDisplay)Task;
            list.Options.Remove(option);

            if (list.SelectedOption == option) list.SelectedOption = "INVALID SELECTION";
            //await UpdateParent();
        }

        private async Task UpdateParent() {
            if (Task.Type != TaskItemType) {
                Task = GroupDisplay.Convert(new TaskItem {
                    Id = this.Task.Id,
                    Type = (int)this.TaskItemType,
                    SortingOrder = this.SortOrder,
                    Label = this.TaskLabel,
                    Comments = this.Task.Comments,
                    Value = this.Task.Value
                });
            }
            else {
                Task.Label = TaskLabel;
                Task.SortOrder = SortOrder;
            }

            await TaskItemChanged.InvokeAsync(Task);
        }

        #endregion

    }
}