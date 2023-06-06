using Radigate.Shared;

namespace Radigate.Client.Services.PatientService {
    public interface IPatientService {
        List<Patient> Patients { get; set; }
        Task GetPatients();
        Task GetPatient(string patientId); 

    }
}
