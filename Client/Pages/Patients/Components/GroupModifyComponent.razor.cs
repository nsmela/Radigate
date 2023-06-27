using Microsoft.AspNetCore.Components;

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
        public GroupDisplay? Group { get; set; } = default!;
        [Parameter]
        public bool Edit { get; set; } = false;
        [Parameter]
        public EventCallback<GroupDisplay> GroupChanged { get; set; } = default!;   
        #endregion

        #region Public Methods and Properties
        #endregion

        #region Internal and Protected Methods/Properties
        protected override async Task OnParametersSetAsync() {
            if (Group is null) return;

            Tasks = new(); 
            foreach (var task in Group.Tasks) {
                var taskItem = task.Copy();
                taskItem.SortOrder = Group.Tasks.IndexOf(task);
                Tasks.Add(taskItem);
            }
            Tasks.OrderBy(t => t.SortOrder).ToList();
            NewLabel = this.Group.Label;
    }

        #endregion

        #region Private Methods/Properties
        
        
        private bool IsEditing(ITaskItem task) => EditingIndex == Tasks.IndexOf(task);
        private string NewTaskIcon => (GroupDisplay.Convert(new TaskItem { Type = (int)NewTaskType })).Icon;

        private int EditingIndex { get; set; } = -1;
        private bool IsEditingName { get; set; } = false;
        private bool IsNewTaskOpen { get; set; } = false;

        private string NewLabel { get; set; } = string.Empty;
        private string NewTaskLabel { get; set; } = string.Empty;
        private TaskType NewTaskType { get; set; } = default!;
        private int SortingOrder { get; set; } = default!;
        private List<ITaskItem> Tasks { get; set; } = new();
        private async Task AddTaskItem() { 
            var task = GroupDisplay.Convert(new TaskItem { Label = NewTaskLabel, Type = (int)NewTaskType }); 
            Tasks.Add(task);

            await UpdateParent();

            NewTaskLabel = String.Empty;
            NewTaskType = default!;
        }
        private void OnTextFieldChangedHandler(bool force = false) {
            if (!force && NewLabel == Group.Label) return;

            Group.Label = NewLabel;
            IsEditingName = false;
        }

        private void DeleteGroup() { }
        private void EditGroupName() {
            IsEditingName = true;
        }

        private async Task OnTaskUpdated(ITaskItem task) {
            EditingIndex = -1;

            //delete the task?
            if (task.SortOrder == -1) {
                Tasks.RemoveAt(Tasks.IndexOf(task));
                foreach (var t in Tasks) t.SortOrder = Tasks.IndexOf(t);
                await UpdateParent();
                return;
            }

            var index = Tasks.IndexOf(task);
            if(index < 0) index = Tasks.FindIndex(g => g.Label == task.Label);
            var oldTask = Tasks[index];

            if(index != task.SortOrder) {
                if (task.SortOrder > Tasks.Count - 1) return; //invalid number

                Tasks.RemoveAt(index);
                Tasks.Insert(task.SortOrder, task);

            }else {
                //update the task value?
                Tasks[index] = task;
            }

            await UpdateParent();
        }

        private async Task OnTaskEditing(ITaskItem task) {
            var index = Tasks.IndexOf(task);

            if (index < 0) return; //bad index

            if (index == EditingIndex) EditingIndex = -1; //select nothing
            else EditingIndex = index;
            //Update parent?
        }

        private async Task UpdateParent() {
            Group.Label = this.NewLabel;
            Group.Tasks = this.Tasks;
            Group.SortingOrder = this.SortingOrder;

            await GroupChanged.InvokeAsync(Group);
        }
        #endregion




            
        


    }
}