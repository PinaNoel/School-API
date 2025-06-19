
using school_api.Application.Common.DTOs;

namespace school_api.Application.Users.DTOs
{


    public class RegisterStudentDTO : BaseUserDTO
    {
        public required int CareerId { get; set; }
    }


    public class RegisterTeacherDTO : BaseUserDTO
    {
        public required string Title { get; set; }
        public required string Speciality { get; set; }
    }


    
}