
namespace Radigate.Client.Services.PatientService {
    public class PatientService : IPatientService {
        private readonly HttpClient _http;

        public List<Patient> Patients { get; set; } = new();

        public PatientService(HttpClient http) {
            _http = http;
        }

        public async Task GetPatients() {
            string requestString = $"/api/Patient";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Patient>>>(requestString);

            if (result is not null && result.Data is not null) 
                Patients = result.Data;
        }

        public async Task<ServiceResponse<Patient>> GetPatient(int patientId) {
            string requestString = $"/api/Patient/{patientId}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<Patient>>(requestString);

            return result;
        }
    }
}
