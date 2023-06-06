using Radigate.Server.Data;

namespace Radigate.Server.Services.PatientService {
    public class PatientService : IPatientService {
        private readonly PatientDataContext _context;

        public PatientService(PatientDataContext context) {
            _context = context;
        }

        public async Task<ServiceResponse<List<Patient>>> GetPatientsAsync() {
            var response = new ServiceResponse<List<Patient>> {
                Data = await _context.Patients.ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Patient>> GetPatientsAsync(string patientId) {
            var response = new ServiceResponse<Patient> {
                Data = await _context.Patients.FindAsync(patientId)
            };

            return response;
        }
    }
}
