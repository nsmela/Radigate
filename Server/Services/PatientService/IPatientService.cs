namespace Radigate.Server.Services.PatientService {
    public interface IPatientService {
        Task<ServiceResponse<List<Patient>>> GetPatientsAsync();
        Task<ServiceResponse<Patient>> GetPatientAsync(int patientId);
        Task<ServiceResponse<List<int>>> GetPatientsIdAsync();
        Task<ServiceResponse<bool>> UpdatePatientAsync(PatientValueItem patient);
    }
}
