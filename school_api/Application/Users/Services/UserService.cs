
using school_api.Application.Common.Interfaces;
using school_api.Application.Common.DTOs;
using school_api.Application.Users.DTOs;
using school_api.Application.Users.Interfaces;
using school_api.Core.Entities;
using school_api.Core.Interfaces;
using System.Text.Json;


namespace school_api.Application.Users.Services
{
    public class UserService : IUserService
    {

        private readonly IPasswordHasherService _passwordHasher;
        private readonly IUnitOfWork _uow;
        private readonly ILogger _logger;

        public UserService(IPasswordHasherService passwordHasher, IUnitOfWork uow, ILogger<UserService> logger)
        {
            _passwordHasher = passwordHasher;
            _uow = uow;
            _logger = logger;
        }


        public async Task CreateStudent(RegisterStudentDTO student)
        {
            User user = new User
            {
                Name = student.Name,
                Surnames = student.Surnames,
                Email = student.Email,
                Enrollment = student.Enrollment,
                Password = student.Password,
            };

            HashResult hashResult = _passwordHasher.HashPassword(user.Password);
            user.PromoteToStudent(student.CareerId);
            user.SetHash(hashResult.Hash, hashResult.Salt);
            await _uow.TransactionAsync(async () =>
            {
                await _uow.Users.AddUser(user);
                // await _uow.Save();
                await _uow.Users.AddStudent(user);
                await _uow.Save();
                _logger.LogInformation($"User = {JsonSerializer.Serialize(user)}");
            });
            _uow.Dispose();
        }
    }
}