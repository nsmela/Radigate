namespace Radigate.Client.Services.TemplateService {
    public class TemplateService : ITemplateService {
        private readonly HttpClient _http;

        public List<GroupTemplate> Groups { get; set; } = new();
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

        public async Task<ServiceResponse<bool>> AddPatientTemplate(NewPatientTemplate template) {
            var connection = $"api/Template/patients";
            var response = await _http.PostAsJsonAsync(connection, template);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }

        public async Task DeleteGroupTemplate(int templateId) {
            var connection = $"api/Template/groups/{templateId}";
            var response = await _http.DeleteAsync(connection);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();

            if (result is null) return;
            await GetAllGroupTemplatesAsync();
        }

        public async Task<ServiceResponse<bool>> DeletePatientTemplate(int templateId) {
            var connection = $"api/Template/patients{templateId}";
            var response = await _http.DeleteAsync(connection);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }

        public async Task GetAllGroupTemplatesAsync() {
            var connection = $"api/Template/groups";
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<GroupTemplate>>>(connection);
            if (response is null || response.Data is null) return;

            Groups = response.Data;
            OnChange?.Invoke();
        }

        public async Task<ServiceResponse<List<PatientTemplate>>> GetAllPatientTemplatesAsync() {
            var connection = $"api/Template/patients";
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<PatientTemplate>>>(connection);
            return response;
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

        public async Task<ServiceResponse<PatientTemplate>> UpdatePatientTemplate(PatientTemplate template) {
            var connection = $"api/Template/patients";
            var response = await _http.PutAsJsonAsync(connection, template);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<PatientTemplate>>();
        }
    }
}
