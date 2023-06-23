using Radigate.Shared.Templates;

namespace Radigate.Client.Services.TemplateService {
    public class TemplateService : ITemplateService {
        private readonly HttpClient _http;

        public List<GroupTemplate> Groups { get; set; } = new();
        public List<PatientTemplate> Patients { get; set; } = new();
        public List<string> PatientNames { get; set; }
        public List<string> GroupNames { get; set; }

        public event Action OnChange;

        public TemplateService(HttpClient http) {
            _http = http;
        }

        public async Task AddGroupTemplate(NewGroupTemplate template) {
            var connection = $"api/Template/groups";
            var response = await _http.PostAsJsonAsync(connection, template);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();

            if (result is null) return;
            await GetAllGroupTemplatesAsync();
        }

        public async Task AddPatientTemplate(NewPatientTemplate template) {
            var connection = $"api/Template/patients";
            var response = await _http.PostAsJsonAsync(connection, template);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();

            if (result is null) return;
            await GetAllPatientTemplatesAsync();
        }

        public async Task DeleteGroupTemplate(int templateId) {
            var connection = $"api/Template/groups/{templateId}";
            var response = await _http.DeleteAsync(connection);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();

            if (result is null) return;
            await GetAllGroupTemplatesAsync();
        }

        public async Task DeletePatientTemplate(int templateId) {
            var connection = $"api/Template/patients/{templateId}";
            var response = await _http.DeleteAsync(connection);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();

            if (result is null) return;
            await GetAllPatientTemplatesAsync();
        }

        public async Task GetAllGroupTemplatesAsync() {
            var connection = $"api/Template/groups";
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<GroupTemplate>>>(connection);
            if (response is null || response.Data is null) return;

            Groups = response.Data;
            GroupNames = new();
            Groups.ForEach(g => GroupNames.Add(g.Label));
            OnChange?.Invoke();
        }

        public async Task GetAllPatientTemplatesAsync() {
            var connection = $"api/Template/patients";
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<PatientTemplate>>>(connection);
            if (response is null || response.Data is null) return;

            Patients = response.Data;
            PatientNames = new();
            Patients.ForEach(p => PatientNames.Add(p.Label));
            OnChange?.Invoke();
        }

        public async Task UpdateGroupTemplate(GroupTemplate template) {
            var connection = $"api/Template/groups";
            var response = await _http.PutAsJsonAsync(connection, template);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<GroupTemplate>>();

            if (result is null || result.Data is null) return;
            var index = Groups.FindIndex(g => g.Id == result.Data.Id);
            Groups[index] = result.Data;

            OnChange?.Invoke();
        }

        public async Task UpdatePatientTemplate(PatientTemplate template) {
            var connection = $"api/Template/patients";
            var response = await _http.PutAsJsonAsync(connection, template);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<PatientTemplate>>();

            if (result is null || result.Data is null) return;
            var index = Patients.FindIndex(p => p.Id == result.Data.Id);
            Patients[index] = result.Data;

            OnChange?.Invoke();
        }
    }
}
