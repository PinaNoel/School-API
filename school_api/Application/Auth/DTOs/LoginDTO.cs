

namespace school_api.Application.Auth.DTOs
{
    public class LoginDTO
    {
        public required string Enrollment { get; set; }
        public required string Password { get; set; }
    }
}