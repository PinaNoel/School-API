

namespace school_api.Application.Common.DTOs
{


    public class BaseUserDTO
    {
        public required string Name { get; set; }
        public required string Surnames { get; set; }
        public required string Email { get; set; }
        public required string Enrollment { get; set; }
        public required string Password { get; set; }
    }


}