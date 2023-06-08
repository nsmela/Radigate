
namespace Radigate.Client.Services.PatientService {
    public class PatientService : IPatientService {
        private readonly HttpClient _http;

        public List<Patient> Patients { get; set; } = new();

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
                foreach(var patient in result.Data) {
                    patients.Add(ConvertPatient(patient));
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

