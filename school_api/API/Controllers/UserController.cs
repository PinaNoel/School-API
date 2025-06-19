

using Microsoft.AspNetCore.Mvc;
using school_api.Application.Users.Interfaces;
using school_api.Application.Users.DTOs;
using school_api.API.DTOs;



namespace school_api.Src.API.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [ValidateModel]   
        [HttpPost]
        [Route("api/v1/[Controller]/CreateStudent")]
        public async Task<IActionResult> CreateStudent([FromBody] RegisterStudentDTO user)
        {
            
            await _userService.CreateStudent(user);

            ReplyDTO response = new ReplyDTO
            {
                statusCode = 201,
                path = ($"{HttpContext.Request.Method} {HttpContext.Request.Path}"),
                message = "User created"
            };

            return StatusCode(201, response);
        }
    }
}