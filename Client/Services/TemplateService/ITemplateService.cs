namespace Radigate.Client.Services.TemplateService {
    public interface ITemplateService {
        Task<ServiceResponse<List<GroupTemplate>>> GetAllGroupTemplatesAsync();
        Task<ServiceResponse<List<PatientTemplate>>> GetAllPatientTemplatesAsync();
        Task<ServiceResponse<bool>> AddGroupTemplate(NewGroupTemplate template);
        Task<ServiceResponse<bool>> AddPatientTemplate(NewPatientTemplate template);
    }
}
