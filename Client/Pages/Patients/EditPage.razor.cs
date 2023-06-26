using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Radigate.Client.Pages.Patients
{
    public partial class EditPage : ComponentBase
    {
        #region Private Variables and Constants
        private PatientDisplay? patient { get; set; } = null;
        private List<TaskGroupModifier> Groups { get; set; } = new();
        private TaskGroup NewTaskGroup { get; set; } = new();
        #endregion

        #region Inject Properties
        [Inject]
        private IPatientService PatientService { get; set; } = default!;
        [Inject]
        NavigationManager NavManager { get; set; } = default!;

        #endregion

        #region Parameter Properties
        [Parameter]
        public int? Id { get; set; } = null;
        #endregion

        #region Public Methods and Properties
        #endregion

        #region Internal and Protected Methods/Properties
        protected override async Task OnParametersSetAsync() {
            if (Id is null) return;
            var response = await PatientService.GetPatient(Id.Value);
            if (!response.Success || response.Data is null) return;

            patient = response.Data;

            Groups = new();

            foreach (var group in patient.TaskGroups) {
                var modGroup = new TaskGroupModifier { Group = group, Tasks = new(), NewLabel = group.Label };
                foreach (var task in group.Tasks) {
                    modGroup.Tasks.Add(new TaskItemModifier { Task = task, Parent = modGroup, NewLabel = task.Label });
                }
                Groups.Add(modGroup);
            }
        }
        #endregion

        #region Private Methods/Properties
        private bool AddGroupOpen { get; set; } = false;

        #region Task Methods/Properties
        private void RaiseTask(TaskItemModifier task) {
            var index = task.Parent.Tasks.IndexOf(task);
            if (index == 0) return;

            task.Parent.Tasks.RemoveAt(index);
            task.Parent.Tasks.Insert(index - 1, task);
        }

        private void LowerTask(TaskItemModifier task) {
            var index = task.Parent.Tasks.IndexOf(task);
            if (index == task.Parent.Tasks.Count - 1) return;

            task.Parent.Tasks.RemoveAt(index);
            task.Parent.Tasks.Insert(index + 1, task);
        }

        private void DeleteTask(TaskGroupModifier group, TaskItemModifier task) {
            group.Tasks.Remove(task);
        }

        private void AddTaskItem(TaskGroupModifier group) {
            if (group.NewTaskLabel == null) return; //label is empty
            if (group.Tasks.FindAll(t => t.Task.Label == group.NewTaskLabel).Count() > 0) return; //if any tasks have the same label
            if (group.NewTaskType < 0) return; //didn't choose a proper type

            var task = new TaskItemModifier {
                NewLabel = group.NewTaskLabel,
                Type = group.NewTaskType,
                Parent = group
            };
            task.Task = NewTask(task);

            group.Tasks.Add(task);

            group.IsNewTaskOpen = false;
            group.NewTaskLabel = string.Empty;
            group.NewTaskType = new();
        }

        private void EditTask(TaskItemModifier task) {
            task.Parent.Tasks.ForEach(t => t.Edit = false);

            task.Edit = true;
        }

        private void EditTaskName(TaskItemModifier task) {
            if (task.Task.Label == task.NewLabel) return; //isn't a new value
            task.Task.Label = task.NewLabel;
            task.Edit = false;
        }

        //list task items
        private void EditTaskListLabel(TaskItemModifier task, string originalValue, string value) {
            var list = (ListDisplay)task.Task;
            int index = list.Options.FindIndex(o => o == originalValue);
            list.Options[index] = value;
        }

        private void AddTaskListItem(TaskItemModifier task) {
            var list = (ListDisplay)task.Task;
            list.Options.Add($"Option {list.Options.Count + 1}");
        }

        private void RemoveTaskListItem(ListDisplay list, string option) {
            list.Options.Remove(option);

            if (list.SelectedOption == option) list.SelectedOption = "INVALID SELECTION";
        }

        private void ChangeTaskType(TaskItemModifier task, TaskType newType) {
            foreach (var group in Groups) {
                var result = group.Tasks.Find(t => t.NewLabel == task.NewLabel);
                if (result is null) continue; ;
                var oldTask = result.Task;

                switch (newType) {
                    case TaskType.Bool:
                        result.Task = new CheckboxDisplay(result.NewLabel);
                        break;
                    case TaskType.Number:
                        result.Task = new NumberDisplay(result.NewLabel);
                        break;
                    case TaskType.Calculation:
                        result.Task = new FormulaDisplay(result.NewLabel);
                        break;
                    case TaskType.Date:
                        result.Task = new DateDisplay(result.NewLabel);
                        break;
                    case TaskType.List:
                        result.Task = new ListDisplay(result.NewLabel);
                        break;
                    default:
                        result.Task = new TextDisplay(result.NewLabel);
                        break;
                }

                result.Task.Comments = oldTask.Comments;

                StateHasChanged();
                return;
            }
        }

        private ITaskItem NewTask(TaskItemModifier task) {
            switch (task.Type) {
                case TaskType.Bool:
                    return new CheckboxDisplay(task.NewLabel);
                case TaskType.Number:
                    return new NumberDisplay(task.NewLabel);
                case TaskType.Calculation:
                    return new FormulaDisplay(task.NewLabel);
                case TaskType.Date:
                    return new DateDisplay(task.NewLabel);
                case TaskType.List:
                    return new ListDisplay(task.NewLabel);
                default:
                    return new TextDisplay(task.NewLabel);
            }
        }
        #endregion

        #region Group Methods/Properties
        private void EditGroupName(TaskGroupModifier group) {
            foreach (var g in Groups) g.EditName = false; //close all group name edits

            group.EditName = true;
        }

        private void OnTextFieldChangedHandler(TaskGroupModifier group) {
            if (group.Group.Label == group.NewLabel) return;
            group.Group.Label = group.NewLabel;
            group.EditName = false;
        }

        private void DeleteGroup(TaskGroupModifier group) {
            Groups.Remove(group);
        }

        private void OnValidGroupSubmit(EditContext context) {
            if (string.IsNullOrEmpty(NewTaskGroup.Label)) return;
            var group = new GroupDisplay { Label = NewTaskGroup.Label, PatientId = patient.Id };
            Groups.Add(new TaskGroupModifier { Group = group, Tasks = new(), NewLabel = group.Label });
            NewTaskGroup.Label = string.Empty;
            AddGroupOpen = false;
        }
        #endregion

        #region Patient Methods/Properties
        private void CancelPatientEdit() => NavManager.NavigateTo($"/patients/view/{Id}");

        private async Task ResetPatientData() {
            await OnParametersSetAsync(); //reloads patient from server based on patient ID
        }

        private async Task SavePatientData() {
            var newPatient = new PatientValueItem {
                PatientId = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Identifier = patient.Identifier
            };

            foreach (var g in Groups) {
                var group = new PatientValueItem.GroupValueItem { Id = g.Group.Id, Label = g.Group.Label };
                foreach (var t in g.Tasks) {
                    group.Tasks.Add(new PatientValueItem.TaskItemValue {
                        Id = t.Task.Id,
                        Label = t.Task.Label,
                        Comments = t.Task.Comments,
                        Type = (int)t.Task.Type,
                        Value = t.Task.Value
                    });
                }
                newPatient.Groups.Add(group);

            }

            await PatientService.UpdatePatient(newPatient);
            NavManager.NavigateTo($"patients/view/{Id}");
        }
        #endregion

        #endregion

        private class TaskGroupModifier {
            public bool Edit { get; set; } = false;
            public bool EditName { get; set; } = false;
            public bool IsNewTaskOpen { get; set; } = false;
            public string NewTaskLabel { get; set; } = string.Empty;
            public TaskType NewTaskType { get; set; }
            public string NewTaskIcon => (GroupDisplay.Convert(new TaskItem { Type = (int)NewTaskType })).Icon;
            public string NewLabel { get; set; } = string.Empty;
            public GroupDisplay Group { get; set; }
            public List<TaskItemModifier> Tasks { get; set; }
        }

        private class TaskItemModifier {
            public bool Edit { get; set; }
            public string NewLabel { get; set; } = string.Empty;
            public TaskType Type { get; set; }
            public ITaskItem Task { get; set; }
            public TaskGroupModifier Parent { get; set; }
            public string Icon => (GroupDisplay.Convert(new TaskItem { Type = (int)Type })).Icon;
        }
    }
}