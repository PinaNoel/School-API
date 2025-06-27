
using System.Security.Claims;
using school_api.Application.Common.Interfaces;

namespace school_api.API.Middlewares
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _context;

        public CurrentUserService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public int UserId
        {
            get
            {
                string? stringId = _context.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

                if (int.TryParse(stringId, out int id))
                {
                    return id;
                }

                return 0;
            }
        }
    }
}