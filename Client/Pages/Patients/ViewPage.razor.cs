using Microsoft.AspNetCore.Components;
using System;

namespace Radigate.Client.Pages.Patients
{
    public partial class ViewPage : ComponentBase
    {
        #region Private Variables and Constants
        private string message = string.Empty;

        #endregion

        #region Inject Properties

        [Inject]
        private IPatientService PatientService { get; set; } = default!;
        [Inject]
        private AuthenticationStateProvider AuthState { get; set; } = default!;
        [Inject]
        private NavigationManager NavManager { get; set; } = default!;

        #endregion

        #region Parameter Properties
        [Parameter] 
        public int Id { get; set; }
        #endregion

        #region Public Methods and Properties
        #endregion

        #region Internal and Protected Methods/Properties
        protected override async Task OnParametersSetAsync() {
            message = "Loading Patient... ";
            var result = await PatientService.GetPatient(Id);

            if (!result.Success) {
                message = result.Message;
            }
            else {
                Patient = result.Data;
            }
        }

        #endregion

        #region Private Methods/Properties
        private PatientDisplay? Patient { get; set; }
        private string PatientName => Patient.LastName.ToUpper() + ", " + Patient.FirstName.ToUpper();
        private void ModifyPatient() => NavManager.NavigateTo($"/patients/edit/{Id}");
        #endregion
    }
}







