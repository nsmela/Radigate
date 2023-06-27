using Radigate.Shared;

namespace Radigate.Client.Services.PatientService {
    public interface IPatientService {
        List<PatientDisplay> Patients { get; set; }
        List<int?> PatientIds { get; set; }
        event Action OnChange;
        Task GetPatients();
        Task<ServiceResponse<PatientDisplay>> GetPatient(int patientId);
        Task UpdatePatientTask(int taskId);
        Task GetPatientsId();
        Task UpdatePatient(PatientValueItem newPatient);
        Task<ServiceResponse<Patient>> AddPatient(NewPatient patient);
        Task DeletePatient(int patientId);
    }
}
