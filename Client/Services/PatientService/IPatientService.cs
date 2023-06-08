using Radigate.Shared;

namespace Radigate.Client.Services.PatientService {
    public interface IPatientService {
        List<Patient> Patients { get; set; }
        Task GetPatients();
        Task<ServiceResponse<Patient>> GetPatient(int patientId);
        Task GetPatientTaskUpdate(int taskId);
    }
}
