namespace Radigate.Server.Services.PatientService {
    public interface IPatientService {
        Task<ServiceResponse<List<Patient>>> GetPatientsAsync();
        Task<ServiceResponse<Patient>> GetPatientAsync(int patientId);
    }
}
