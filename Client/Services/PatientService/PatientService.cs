namespace Radigate.Client.Services.PatientService {
    public class PatientService : IPatientService {
        private readonly HttpClient _http;

        public List<PatientDisplay> Patients { get; set; } = new();

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

        public async Task<PatientDisplay> GetPatientDisplay(int patientId) {
            string requestString = $"/api/Patient/{patientId}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<Patient>>(requestString);

            if (result is not null && result.Data is not null)
                return new PatientDisplay(result.Data);

            return null;
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

        public async Task<ServiceResponse<List<int>>> GetPatientsId() {
            string requestString = $"/api/Patient/ids";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<int>>>(requestString);

            return result;
        }

        public async Task UpdatePatient(PatientValueItem newPatient) {
            string connection = $"/api/Patient/update";
            await _http.PutAsJsonAsync(connection, newPatient);
        }

        //TaskItem is converted into The relevent TaskType
        private Patient ConvertPatient(Patient patient) {
            foreach (var group in patient.TaskGroups) {
                var tasks = new List<TaskItem>();
                foreach (var task in group.Tasks) {
                    tasks.Add(TaskItem.Convert(task));
                }
                group.Tasks = tasks;
            }
            return patient;
        }
    }


}

