
using Microsoft.AspNetCore.Mvc;
using Auth = school_api.Application.Auth;

namespace school_api.API.Controllers
{
    public class AuthController : Controller
    {
        private readonly Auth.Interfaces.IAuthService _authService;

        public AuthController(Auth.Interfaces.IAuthService authService)
        {
            _authService = authService;
        }


        [ValidateModel]
        [HttpPost]
        [Route("api/v1/[Controller]/Login")]   
        public async Task<IActionResult> Login([FromBody] Auth.DTOs.LoginDTO authDTO)
        {
            Auth.DTOs.LoginResponseDTO response = await _authService.Login(authDTO);

            return StatusCode(201, response);
        }
    }
}