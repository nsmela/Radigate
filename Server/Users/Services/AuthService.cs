using Radigate.Server.Data;
using Radigate.Server.Users.Data;
using System.Security.Cryptography;

namespace Radigate.Server.Users.Services {
    public class AuthService : IAuthService {
        private readonly UsersContext _context;

        public AuthService(UsersContext context) {
            _context = context;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password) {
            if(await UserExists(user.Email)) {
                return new ServiceResponse<int> { Success = false, Message = "User already exists!" };
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Success = true, Data = user.Id };
        }

        public async Task<bool> UserExists(string emailAddress) {
            var email = emailAddress.ToLower(); //prevents formatting multiple times while searching
            return await _context.Users.AnyAsync(user => user.Email.ToLower().Equals(email));
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) {
            using (var hmac = new HMACSHA512()) {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
