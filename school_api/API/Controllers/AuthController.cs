
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Auth = school_api.Application.Auth;

namespace school_api.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : Controller
    {
        private readonly Auth.Interfaces.IAuthService _authService;

        public AuthController(Auth.Interfaces.IAuthService authService)
        {
            _authService = authService;
        }


        [ValidateModel]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Auth.DTOs.LoginDTO authDTO)
        {
            Auth.DTOs.LoginResponseDTO response = await _authService.Login(authDTO);

            return StatusCode(200, response);
        }


        [HttpPut("ChangePassword")]
        [ValidateModel]
        [Authorize(Roles = "Admin, Teacher, Student")]
        public async Task<IActionResult> ChangePassword([FromBody] Auth.DTOs.ChangePasswordDTO passwordDTO)
        {
            await _authService.ChangePassword(passwordDTO);

            return StatusCode(201);
        }
    }
}