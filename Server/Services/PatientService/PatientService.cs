using Radigate.Server.Data;

namespace Radigate.Server.Services.PatientService {
    public class PatientService : IPatientService {
        private readonly PatientDataContext _context;

        public PatientService(PatientDataContext context) {
            _context = context;
        }

        //https://www.youtube.com/watch?v=UBNRcaw1bDk
        public async Task<ServiceResponse<List<Patient>>> GetPatientsAsync() {
            var response = new ServiceResponse<List<Patient>> {
                Data = await _context.Patients
                    .Include(p => p.TaskGroups)
                    .ThenInclude(g => g.Tasks)
                    .ToListAsync()
            };

            return response;
        }

        //https://learn.microsoft.com/en-us/ef/ef6/fundamentals/relationships

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
