
using school_api.Application.Users.DTOs;
using school_api.Core.Entities;

namespace school_api.Application.Users.Interfaces
{
    public interface IUserService
    {
        public Task CreateStudent(RegisterStudentDTO student);
    }
}