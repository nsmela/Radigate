using Radigate.Shared;

namespace Radigate.Client.Services.PatientService {
    public interface IPatientService {
        List<PatientDisplay> Patients { get; set; }
        Task GetPatients();
        Task<ServiceResponse<PatientDisplay>> GetPatient(int patientId);
        Task UpdatePatientTask(int taskId);
        Task<ServiceResponse<List<int>>> GetPatientsId();
        Task UpdatePatient(PatientValueItem newPatient);
    }
}
