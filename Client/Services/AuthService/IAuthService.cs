namespace Radigate.Client.Services.AuthService {
    public interface IAuthService {
        Task<ServiceResponse<int>> Register(UserRegisteration request);
    }
}
