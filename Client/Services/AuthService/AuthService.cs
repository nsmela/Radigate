namespace Radigate.Client.Services.AuthService {
    public class AuthService : IAuthService {
        private readonly HttpClient _http;

        public AuthService(HttpClient http) {
            _http = http;
        }

        public async Task<ServiceResponse<string>> Signin(UserLogin request) {
            var connection = $"api/Auth/signin";
            var response = await _http.PostAsJsonAsync(connection, request);

            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<int>> Register(UserRegisteration request) {
            var connection = $"api/Auth/register";
            var response = await _http.PostAsJsonAsync(connection, request);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request) {
            var connection = $"api/Auth/change-password";
            var response = await _http.PostAsJsonAsync(connection, request.Password);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }
    }
}
