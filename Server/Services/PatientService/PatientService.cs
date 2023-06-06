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

        public async Task<ServiceResponse<Patient>> GetPatientAsync(int patientId) {
            var response = new ServiceResponse<Patient>();

            var patient = await _context.Patients.FindAsync(patientId);

            if (patient is null) {
                response.Success = false;
                response.Message = "Patient is not found";
            }
            else {
                response.Data = patient;
            }

            return response;
        }
    }
}
