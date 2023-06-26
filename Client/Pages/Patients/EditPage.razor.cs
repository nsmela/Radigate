using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Radigate.Client.Pages.Patients
{
    public partial class EditPage : ComponentBase
    {
        #region Private Variables and Constants

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

            Patient = response.Data;

        }
        #endregion

        #region Private Methods/Properties
        private bool AddGroupOpen { get; set; } = false;
        private PatientDisplay? Patient { get; set; } = null;
        private List<GroupDisplay> Groups => Patient.TaskGroups;
        private TaskGroup NewTaskGroup { get; set; } = new();


        #region Group Methods/Properties
        private void OnValidGroupSubmit(EditContext context) {
            if (string.IsNullOrEmpty(NewTaskGroup.Label)) return;
            var group = new GroupDisplay { Label = NewTaskGroup.Label, PatientId = Patient.Id };
            Groups.Add(group);
            NewTaskGroup.Label = string.Empty;
            AddGroupOpen = false;
        }

        private async Task OnGroupUpdated(GroupDisplay newGroup) {
            var index = Groups.IndexOf(newGroup);
            Groups[index] = newGroup;
            StateHasChanged();
        }
        #endregion

        #region Patient Methods/Properties
        private void CancelPatientEdit() => NavManager.NavigateTo($"/patients/view/{Id}");

        private async Task ResetPatientData() {
            await OnParametersSetAsync(); //reloads patient from server based on patient ID
        }

        private async Task SavePatientData() {
            var newPatient = new PatientValueItem {
                PatientId = Patient.Id,
                FirstName = Patient.FirstName,
                LastName = Patient.LastName,
                Identifier = Patient.Identifier
            };

            foreach (var g in Groups) {
                var group = new PatientValueItem.GroupValueItem { Id = g.Id, Label = g.Label };
                foreach (var t in g.Tasks) {
                    group.Tasks.Add(new PatientValueItem.TaskItemValue {
                        Id = t.Id,
                        Label = t.Label,
                        Comments = t.Comments,
                        Type = (int)t.Type,
                        Value = t.Value
                    });
                }
                newPatient.Groups.Add(group);

            }

            await PatientService.UpdatePatient(newPatient);
            NavManager.NavigateTo($"patients/view/{Id}");
        }
        #endregion

        #endregion


    }
}