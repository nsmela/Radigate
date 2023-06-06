
namespace Radigate.Client.Services.PatientService {
    public class PatientService : IPatientService {
        private readonly HttpClient _http;

        public List<Patient> Patients { get; set; } = new();

        public PatientService(HttpClient http) {
            _http = http;
        }

        public async Task GetPatient(string patientId) {
            throw new NotImplementedException();
        }

        public async Task GetPatients() {
            string requestString = $"/api/Patient";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Patient>>>(requestString);

            if (result is not null && 
                result.Data is not null) Patients = result.Data;
        }
    }
}
