
using school_api.Core.Interfaces;
using school_api.Core.Entities;
using school_api.Application.Common.Errors;
using school_api.Application.Common.Interfaces;
using school_api.Application.Common.DTOs;
using school_api.Application.Auth.DTOs;
using school_api.Application.Auth.Interfaces;
using System.Text.Json;


namespace school_api.Application.Auth.Services
{
    public class AuthService : IAuthService
    {

        private readonly IUnitOfWork _uow;
        private readonly IPasswordHasherService _passwordHasher;
        private readonly IJwtService _jwtService;
        private readonly ILogger _logger;

        public AuthService(IUnitOfWork uow, IPasswordHasherService passwordHasher, IJwtService jwtService, ILogger<AuthService> logger)
        {
            _uow = uow;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
            _logger = logger;
        }


        public async Task<LoginResponseDTO> Login(LoginDTO credentials)
        {
            User? user = await _uow.Users.GetUserCredentials(credentials.Enrollment);

            if (user == null) throw new NotFoundError("User not found");

            _logger.LogInformation(JsonSerializer.Serialize(user));
            VerifyHash verifyHash = new()
            {
                Password = credentials.Password,
                Hash = user.Hash!,
                Salt = user.Salt!,
            };

            bool isValid = _passwordHasher.Verify(verifyHash);

            if (!isValid) throw new ForbiddenError("The password is incorrect");
            if (user.IsActive == false) throw new ForbiddenError("User is not active");

            string jwt = _jwtService.GenerateToken(user);
            LoginResponseDTO response = new()
            {
                Role = user.Role!,
                Token = jwt
            };

            return response;
        }
    }
}