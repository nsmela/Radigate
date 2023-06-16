using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
