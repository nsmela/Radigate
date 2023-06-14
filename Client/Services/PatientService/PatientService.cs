namespace Radigate.Client.Services.PatientService {
    public class PatientService : IPatientService {
        private readonly HttpClient _http;

        public List<Patient> Patients { get; set; } = new();
        public List<PatientDisplay> PatientDisplays { get; set; } = new();  //refactored patients

        public PatientService(HttpClient http) {
            _http = http;
        }

        //cannot deserialize the objects normally
        //https://www.puresourcecode.com/dotnet/csharp/derived-classes-with-system-text-json/
        public async Task GetPatients() {
            string requestString = $"/api/Patient";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Patient>>>(requestString);

            if (result is not null && result.Data is not null) {
                var patients = new List<Patient>();
                PatientDisplays = new();
                foreach(var patient in result.Data) {
                    patients.Add(ConvertPatient(patient));
                    PatientDisplays.Add(new PatientDisplay(patient)); //refactored
                }
                Patients = patients;
                return;
            }

            Patients = new();
        }

        public async Task<ServiceResponse<Patient>> GetPatient(int patientId) {
            string requestString = $"/api/Patient/{patientId}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<Patient>>(requestString);

            if(result is not null && result.Data is not null) 
                result.Data = ConvertPatient(result.Data);

            return result;
        }

        public async Task<PatientDisplay> GetPatientDisplay(int patientId) {
            string requestString = $"/api/Patient/{patientId}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<Patient>>(requestString);

            if (result is not null && result.Data is not null)
                return new PatientDisplay(result.Data);

            return null;
        }

        public async Task GetPatientTaskUpdate(int taskId) {
            string connection = $"/api/Task/{taskId}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<TaskItem>>(connection);
            if (result is not null && result.Data is not null) {
                for (int i = 0; i < Patients.Count; i++) {
                    for (int j = 0; j < Patients[i].TaskGroups.Count; j++) {
                        for(int k = 0; k < Patients[i].TaskGroups.ElementAt(j).Tasks.Count; k++) {
                            if (Patients[i].TaskGroups.ElementAt(j).Tasks.ElementAt(k).Id == taskId) {
                                var tasks = new List<TaskItem>();
                                foreach(var t in Patients[i].TaskGroups.ElementAt(j).Tasks) {
                                    if (t.Id == taskId) {
                                        var task = TaskItem.Convert(result.Data);
                                        task.TaskGroup = Patients[i].TaskGroups.ElementAt(j);
                                        tasks.Add(task);
                                    }
                                    else {
                                        tasks.Add(Patients[i].TaskGroups.ElementAt(j).Tasks.ElementAt(k));
                                    }
                                }
                                return;
                            }
                        }
                    }
                }
            }
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
            foreach(var patient in PatientDisplays) {
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

