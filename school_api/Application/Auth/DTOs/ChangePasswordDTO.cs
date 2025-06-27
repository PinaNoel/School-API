

namespace school_api.Application.Auth.DTOs
{
    public class ChangePasswordDTO
    {
        public required string Enrollment { get; set; }
        public required string Password { get; set; }
        public required string NewPassword { get; set; }
        public required string ConfirmNewPasword { get; set; }
    }
}