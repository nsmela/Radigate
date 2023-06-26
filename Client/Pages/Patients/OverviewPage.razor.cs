using Microsoft.AspNetCore.Components;

namespace Radigate.Client.Pages.Patients
{
    public partial class OverviewPage : ComponentBase {
        #region Private Variables and Constants
        #endregion

        #region [Inject] Properties

        [Inject]
        private IPatientService PatientService { get; set; } = default!;
        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

        #endregion

        #region Parameter Properties
        #endregion

        #region Public Methods and Properties
        #endregion

        #region Internal and Protected Methods/Properties
        protected override async Task OnInitializedAsync() {
            var response = await PatientService.GetPatientsId();

            if (!response.Success || response.Data is null || response.Data.Count < 1) return;

            patientIds = new();
            response.Data.ForEach(p => patientIds.Add(p));
        }

        #endregion

        #region Private Methods/Properties
        private List<int?> patientIds { get; set; } = new List<int?> { null, null, null, null, null, null }; //to create multiple shadows while loading patients

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