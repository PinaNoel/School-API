
using school_api.Core.Entities;

namespace school_api.Application.Common.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}