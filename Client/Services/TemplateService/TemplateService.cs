namespace Radigate.Client.Services.TemplateService {
    public class TemplateService : ITemplateService {
        private readonly HttpClient _http;

        public TemplateService(HttpClient http) {
            _http = http;
        }

        public async Task<ServiceResponse<bool>> AddGroupTemplate(NewGroupTemplate template) {
            var connection = $"api/Template/groups";
            var response = await _http.PostAsJsonAsync(connection, template);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }

        public async Task<ServiceResponse<bool>> AddPatientTemplate(NewPatientTemplate template) {
            var connection = $"api/Template/patients";
            var response = await _http.PostAsJsonAsync(connection, template);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }

        public async Task<ServiceResponse<List<GroupTemplate>>> GetAllGroupTemplatesAsync() {
            var connection = $"api/Template/groups";
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<GroupTemplate>>>(connection);
            return response;
        }

        public async Task<ServiceResponse<List<PatientTemplate>>> GetAllPatientTemplatesAsync() {
            var connection = $"api/Template/patients";
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<PatientTemplate>>>(connection);
            return response;
        }

        public async Task<ServiceResponse<GroupTemplate>> UpdateGroupTemplate(GroupTemplate template) {
            var connection = $"api/Template/groups";
            var response = await _http.PutAsJsonAsync(connection, template);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<GroupTemplate>>();
        }

        public async Task<ServiceResponse<PatientTemplate>> UpdatePatientTemplate(PatientTemplate template) {
            var connection = $"api/Template/patients";
            var response = await _http.PutAsJsonAsync(connection, template);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<PatientTemplate>>();
        }
    }
}
