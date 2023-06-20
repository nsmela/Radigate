namespace Radigate.Server.Templates.Services {
    public interface ITemplateService {
        //read
        Task<ServiceResponse<List<PatientTemplate>>> GetAllPatientTemplatesAsync();
        Task<ServiceResponse<List<GroupTemplate>>> GetAllGroupTemplatesAsync();
        Task<ServiceResponse<PatientTemplate>> GetPatientTemplateAsync(int templateId);
        Task<ServiceResponse<GroupTemplate>> GetGroupTemplateAsync(int templateId);

        //update
        Task<ServiceResponse<PatientTemplate>> UpdatePatientTemplate(PatientTemplate updatedTemplate);
        Task<ServiceResponse<GroupTemplate>> UpdateGroupTemplate(GroupTemplate updatedTemplate);

        //create
        Task<ServiceResponse<bool>> AddPatientTemplateAsync(NewPatientTemplate newTemplate);
        Task<ServiceResponse<bool>> AddGroupTemplateAsync(NewGroupTemplate newTemplate);
    }
}
