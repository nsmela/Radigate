namespace Radigate.Client.Services.TemplateService {
    public interface ITemplateService {
        List<GroupTemplate> Groups { get; set; }
        List<PatientTemplate> Patients { get; set; }
        List<string> PatientNames { get; set; }
        List<string> GroupNames { get; set; }
        event Action OnChange;
        
        Task GetAllGroupTemplatesAsync();
        Task GetAllPatientTemplatesAsync();
        Task AddGroupTemplate(NewGroupTemplate template);
        Task AddPatientTemplate(NewPatientTemplate template);
        Task UpdateGroupTemplate(GroupTemplate template);
        Task UpdatePatientTemplate(PatientTemplate template);
        Task DeleteGroupTemplate(int templateId);
        Task DeletePatientTemplate(int templateId);   
    }
}
