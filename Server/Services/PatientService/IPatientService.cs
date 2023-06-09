﻿namespace Radigate.Server.Services.PatientService {
    public interface IPatientService {
        Task<ServiceResponse<List<Patient>>> GetPatientsAsync();
        Task<ServiceResponse<List<Patient>>> AdminGetPatientsAsync();
        Task<ServiceResponse<Patient>> GetPatientAsync(int patientId);
        Task<ServiceResponse<List<int>>> GetPatientsIdAsync();
        Task<ServiceResponse<List<int>>> AdminGetPatientsIdAsync();
        Task<ServiceResponse<bool>> UpdatePatientAsync(PatientValueItem patient);
        Task<ServiceResponse<Patient>> AddPatient(NewPatient patient);
        Task<ServiceResponse<List<Patient>>> DeletePatient(int patientId);
        Task<ServiceResponse<List<Patient>>> ArchivePatient(int patientId, bool archived);
    }
}
