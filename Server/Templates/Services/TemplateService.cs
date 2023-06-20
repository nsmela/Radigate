namespace Radigate.Server.Templates.Services {
    public class TemplateService : ITemplateService {
        public async Task<ServiceResponse<bool>> AddGroupTemplateAsync(NewGroupTemplate newTemplate) {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<bool>> AddPatientTemplateAsync(NewPatientTemplate newTemplate) {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GroupTemplate>>> GetAllGroupTemplatesAsync() {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<GroupTemplate>> GetGroupTemplateAsync(int templateId) {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<PatientTemplate>>> GetAllPatientTemplatesAsync() {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<PatientTemplate>> GetPatientTemplateAsync(int templateId) {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<GroupTemplate>> UpdateGroupTemplate(GroupTemplate updatedTemplate) {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<PatientTemplate>> UpdatePatientTemplate(PatientTemplate updatedTemplate) {
            throw new NotImplementedException();
        }
    }
}
