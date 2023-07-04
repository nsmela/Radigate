namespace Radigate.Client.Services.PatientService {
    public class PatientService : IPatientService {
        private readonly HttpClient _http;

        public List<PatientDisplay> Patients { get; set; } = new();
        public List<int?> PatientIds { get; set; } = new();
        public event Action OnChange;
        public PatientService(HttpClient http) {
            _http = http;
        }

        //cannot deserialize the objects normally
        //https://www.puresourcecode.com/dotnet/csharp/derived-classes-with-system-text-json/
        public async Task GetPatients() {
            string requestString = $"/api/Patient";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Patient>>>(requestString);

            Patients = new();

            if (result is not null && result.Data is not null) {
                foreach(var patient in result.Data) Patients.Add(new PatientDisplay(patient)); //refactored
            }
            OnChange?.Invoke();
        }

        public async Task<ServiceResponse<PatientDisplay>> GetPatient(int patientId) {
            string requestString = $"/api/Patient/{patientId}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<Patient>>(requestString);

            var response = new ServiceResponse<PatientDisplay>();

            if(result is not null && result.Data is not null) {
                //converting from Patient to PatientDisplay
                response.Success = result.Success;
                response.Message = result.Message;
                response.Data = result.Data is null ? null : new PatientDisplay(result.Data);
            }

            return response;
        }

        //refactored
        /// <summary>
        /// Have the patient Service update itself by looking for a new specific task
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public async Task UpdatePatientTask(int taskId) {
            string connection = $"/api/Task/{taskId}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<TaskItem>>(connection);

            if (result is null || result.Data is null) return;
            var task = GroupDisplay.Convert(result.Data); //had to store the static method somewhere
            foreach(var patient in Patients) {
                patient.TaskGroups.ForEach(g => {
                    if (g.Id == task.TaskGroupId) {
                        var oldTask = g.Tasks.FirstOrDefault(t => t.Id == task.Id);
                        if (oldTask is null) g.Tasks.Add(task);
                        else oldTask = task;

                        g.Tasks.OrderBy(t => t.SortOrder).ToList(); //sort by order
                        return;
                    }
                });
            }
        }

        public async Task GetPatientsId() {
            string requestString = $"/api/Patient/ids";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<int>>>(requestString);

            PatientIds = new();
            if(result is null || result.Data is null || result.Data.Count < 1) return;
            foreach (var id in result.Data) PatientIds.Add((int?)id);

            OnChange?.Invoke();
        }

        public async Task UpdatePatient(PatientValueItem newPatient) {
            string connection = $"/api/Patient/update";
            await _http.PutAsJsonAsync(connection, newPatient);
        }

        public async Task<ServiceResponse<Patient>> AddPatient(NewPatient patient) {
            string connection = $"/api/Patient";
            var response = await _http.PostAsJsonAsync(connection, patient);

            return await response.Content.ReadFromJsonAsync<ServiceResponse<Patient>>();
        }

        public async Task DeletePatient(int taskId) {
            string connection = $"/api/Patient/{taskId}";
            var response = await _http.DeleteAsync(connection);

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Patient>>>();
            Patients = new();
            PatientIds = new();

            if (result is not null && result.Data is not null) {
                foreach (var patient in result.Data) {
                    Patients.Add(new PatientDisplay(patient)); //refactored
                    PatientIds.Add(patient.Id);
                }
            }

            OnChange?.Invoke();
        }

    }
}

