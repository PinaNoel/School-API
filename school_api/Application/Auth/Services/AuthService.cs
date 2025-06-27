
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
        private readonly ICurrentUserService _currentUser;

        public AuthService(IUnitOfWork uow, IPasswordHasherService passwordHasher, IJwtService jwtService, ILogger<AuthService> logger, ICurrentUserService currentUser)
        {
            _uow = uow;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
            _logger = logger;
            _currentUser = currentUser;
        }


        public async Task<LoginResponseDTO> Login(LoginDTO credentials)
        {
            User? user = await _uow.Users.GetUserCredentials(credentials.Enrollment);
            _uow.Dispose();

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


        public async Task ChangePassword(ChangePasswordDTO passwordDTO)
        {
            if(_currentUser.UserId is 0)
                throw new UnauthorizedError("The token does not contain an identifier");

            if (passwordDTO.ConfirmNewPasword != passwordDTO.NewPassword)
                throw new BadRequestError("The password must match the confirmation");

            User? user = await _uow.Users.GetPassword(_currentUser.UserId) ?? throw new NotFoundError("User not found");

            VerifyHash verifyHash = new()
            {
                Password = passwordDTO.Password,
                Hash = user.Hash!,
                Salt = user.Salt!,
            };

            if (!_passwordHasher.Verify(verifyHash)) throw new UnauthorizedError("The password is incorrect");

            user.Password = passwordDTO.NewPassword;
            
            HashResult newHash = _passwordHasher.HashPassword(user.Password);

            user.SetHash(newHash.Hash, newHash.Salt);

            await _uow.TransactionAsync(async () =>
            {
                await _uow.Users.ChangePassword(user);
                await _uow.Save();
            });

            _uow.Dispose();
        }
    }
}