

namespace school_api.Application.Auth.DTOs
{
    public class LoginResponseDTO
    {
        public required string Role { get; set; }
        public required string Token { get; set; }
    }
}