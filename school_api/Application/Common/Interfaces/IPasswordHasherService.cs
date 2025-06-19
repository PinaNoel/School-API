
using school_api.Application.Common.DTOs;

namespace school_api.Application.Common.Interfaces
{
    public interface IPasswordHasherService
    {
        byte[] GenerateSalt();
        HashResult HashPassword(string password);
        bool Verify(VerifyHash verify);
    }
}