using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Radigate.Server.Users.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Regsiter(UserRegisteration request) {
            var response = await _authService.Register(new User { Email = request.Email }, request.Password);

            if(response.Success) return Ok(response);
            else return BadRequest(response);
        }

        [HttpPost("signin")]
        public async Task<ActionResult<ServiceResponse<string>>> Signin(UserLogin request) {
            var response = await _authService.Login(request.Email, request.Password);

            if (response.Success) return Ok(response);
            else return BadRequest(response);
        }

        [HttpPost("change-password"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword([FromBody] string newPassword) {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _authService.ChangePassword(int.Parse(userId), newPassword);

            if (response.Success) return Ok(response);
            else return BadRequest(response);
        }
    }
}
