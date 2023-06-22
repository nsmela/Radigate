namespace Radigate.Client.Services.TemplateService {
    public interface ITemplateService {
        List<GroupTemplate> Groups { get; set; }
        event Action OnChange;
        Task  GetAllGroupTemplatesAsync();
        Task<ServiceResponse<List<PatientTemplate>>> GetAllPatientTemplatesAsync();
        Task AddGroupTemplate(NewGroupTemplate template);
        Task<ServiceResponse<bool>> AddPatientTemplate(NewPatientTemplate template);
        Task UpdateGroupTemplate(GroupTemplate template);
        Task<ServiceResponse<PatientTemplate>> UpdatePatientTemplate(PatientTemplate template);
        Task DeleteGroupTemplate(int templateId);
        Task<ServiceResponse<bool>> DeletePatientTemplate(int templateId);   
    }
}
