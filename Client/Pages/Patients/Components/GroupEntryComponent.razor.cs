
using Microsoft.AspNetCore.Components;

namespace Radigate.Client.Pages.Patients.Components
{
    public partial class GroupEntryComponent : ComponentBase
    {
        #region Private Variables and Constants
        #endregion

        #region Inject Properties
        [Inject]
        private ITaskService TaskService { get; set; } = default!;
        #endregion

        #region Parameter Properties
        [Parameter]
        public GroupDisplay? Group { get; set; } = default!;
        #endregion

        #region Public Methods and Properties
        #endregion

        #region Internal and Protected Methods/Properties
        #endregion

        #region Private Methods/Properties

        private async Task UpdatePatientTask(ITaskItem task, string value) {
            await TaskService.UpdateTaskValue(task.Id, value);
        }
        #endregion
    }
}