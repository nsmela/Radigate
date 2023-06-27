using Microsoft.AspNetCore.Components;

namespace Radigate.Client.Pages.Patients.Components
{
    public partial class PatientViewComponent : ComponentBase
    {
        #region Private Variables and Constants
        #endregion

        #region Inject Properties

        [Inject] 
        private IPatientService PatientService { get; set; }
        [Inject] 
        private NavigationManager NavigationManager { get; set; }

        #endregion

        #region Parameter Properties

        [Parameter] 
        public int? PatientId { get; set; }

        #endregion

        #region Public Methods and Properties
        #endregion

        #region Internal and Protected Methods/Properties
        protected override async Task OnParametersSetAsync() {
            if (PatientId is null) return;

            var result = await PatientService.GetPatient(PatientId.Value);

            message = string.Empty;
            if (result is null) return;
            if (!result.Success) message = result.Message;

            Patient = result.Data;
        }


        #endregion

        #region Private Methods/Properties
        private PatientDisplay? Patient { get; set; } = null;
        private string message { get; set; } = "Accessing patient";
        private string Name => Patient.LastName + ", " + Patient.FirstName;


        private async Task UpdatePatientTask(string groupLabel, string label, object value) {
        }

        private void EditPatient() => NavigationManager.NavigateTo($"patients/view/{Patient.Id}");
        private async Task ModifyPatient() => NavigationManager.NavigateTo($"patients/edit/{Patient.Id}");
        private async Task DeletePatient() => PatientService.DeletePatient(PatientId.Value);
        #endregion
    }
}




