using Microsoft.AspNetCore.Components;

namespace Radigate.Client.Pages.Patients
{
    public partial class OverviewPage : ComponentBase {
        #region Private Variables and Constants
        #endregion

        #region Inject Properties

        [Inject]
        private IPatientService PatientService { get; set; } = default!;
        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

        #endregion

        #region Parameter Properties
        #endregion

        #region Public Methods and Properties
        public void Dispose() {
            PatientService.OnChange -= StateHasChanged;
        }
        #endregion

        #region Internal and Protected Methods/Properties
        protected override async Task OnInitializedAsync() {
            PatientService.OnChange += StateHasChanged;

            await PatientService.GetPatientsId();
        }

        #endregion

        #region Private Methods/Properties
        private List<int?> patientIds {
            get {
                if (PatientService is null || PatientService.PatientIds is null) return new List<int?> { null, null, null, null, null, null }; //to create multiple shadows while loading patients
                else return PatientService.PatientIds;
            }
        }
        private void AddPatient() => NavigationManager.NavigateTo($"/patients/new");
        private void PatientDataEntry(int id) => NavigationManager.NavigateTo($"patients/{id}");

        #endregion
    }
}

#region Private Variables and Constants
#endregion

#region Inject Properties
#endregion

#region Parameter Properties
#endregion

#region Public Methods and Properties
#endregion

#region Internal and Protected Methods/Properties
#endregion

#region Private Methods/Properties
#endregion