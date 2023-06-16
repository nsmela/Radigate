using Radigate.Server.Data;
using Radigate.Server.Users.Data;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Radigate.Server.Users.Services {
    public class AuthService : IAuthService {
        private readonly UsersContext _context;

        public AuthService(UsersContext context) {
            _context = context;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password) {
            if(await UserExists(user.Email)) 
                return new ServiceResponse<int> { Success = false, Message = "User already exists!" };
            if (password.Length < 6)
                return new ServiceResponse<int> { Success = false, Message = "Password must be at least of length 6" };
            if (!Regex.IsMatch(password, @"[A-Z]"))
                return new ServiceResponse<int> { Success = false, Message = "Password must contain at least one capital letter" };
            if (!Regex.IsMatch(password, @"[a-z]"))
                return new ServiceResponse<int> { Success = false, Message = "Password must contain at least one lowercase letter" };
            if (!Regex.IsMatch(password, @"[0-9]"))
                return new ServiceResponse<int> { Success = false, Message = "Password must contain at least one digit" };

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
