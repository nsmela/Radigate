using Radigate.Server.Data;
using Radigate.Server.Users.Data;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;
using System.IdentityModel.Tokens.Jwt;

namespace Radigate.Server.Users.Services {
    public class AuthService : IAuthService {
        private readonly UsersContext _context;
        private readonly IConfiguration _config;

        public AuthService(UsersContext context, IConfiguration config) {
            _context = context;
            _config = config;
        }

        public async Task<ServiceResponse<string>> Login(string emailAddress, string password) {
            var email = emailAddress.ToLower();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email);

            if (user is null) return new ServiceResponse<string> { Success = false, Message = "Email address not found!" };
            if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) return new ServiceResponse<string> { Success = false, Message = "Password does not match!" };

            return new ServiceResponse<string> { Data = CreateToken(user) };

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

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) {
            using (var hmac = new HMACSHA512(passwordSalt)) {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user) {

            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
