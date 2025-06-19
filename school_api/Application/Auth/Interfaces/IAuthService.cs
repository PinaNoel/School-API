
using school_api.Application.Auth.DTOs;

namespace school_api.Application.Auth.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> Login(LoginDTO credentials);
    }
}