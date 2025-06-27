
using Microsoft.EntityFrameworkCore;
using school_api.Core.Entities;
using school_api.Core.Interfaces;
using school_api.Application.Common.Errors;

using school_api.Infrastructure.Context;
using EfModels = school_api.Infrastructure.Models;


namespace school_api.Infrastructure.Repositories
{

    public class UsersRepository : IUsersRepository
    {

        private readonly SchoolDataBaseContext _context;
        private readonly ILogger _logger;

        public UsersRepository(SchoolDataBaseContext context, ILogger<UsersRepository> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task AddUser(User user)
        {
            EfModels.User efUser = new()
            {
                Name = user.Name,
                Surnames = user.Surnames,
                Email = user.Email,
                Enrollment = user.Enrollment,
                Salt = user.Salt,
                Password = user.Hash,
                Role = user.Role,
                IsActive = user.IsActive,
            };

            await _context.Users.AddAsync(efUser);
            await _context.SaveChangesAsync();
            user.Id = efUser.Id;
        }


        public async Task AddStudent(User user)
        {
            EfModels.Student efStudent = new()
            {
                UserId = user.Id,
                CareerId = user.Student!.CareerId,
            };

            await _context.Students.AddAsync(efStudent);
        }


        public async Task<User?> GetUserCredentials(string enrollment)
        {
            EfModels.User? efUser = await _context.Users
            .Where(u => u.Enrollment == enrollment)
            .Select(u => new EfModels.User { Id = u.Id, Password = u.Password, Salt = u.Salt, Role = u.Role, IsActive = u.IsActive })
            .FirstOrDefaultAsync();

            if (efUser == null) return null;

            User user = new()
            {
                Id = efUser.Id,
                Enrollment = enrollment,
                IsActive = efUser.IsActive
            };

            user.UpdateRole(efUser.Role!);
            user.SetHash(efUser.Password!, efUser.Salt!);
            return user;
        }


        public async Task<User?> GetPassword(int id)
        {
            EfModels.User? efUser = await _context.Users
            .Where(u => u.Id == id)
            .Select(u => new EfModels.User { Id = u.Id, Password = u.Password, Salt = u.Salt })
            .FirstOrDefaultAsync();

            if (efUser == null) return null;

            User user = new()
            {
                Id = efUser.Id
            };

            user.SetHash(efUser.Password!, efUser.Salt!);
            return user;
        }


        public async Task ChangePassword(User user)
        {
            EfModels.User? efUser = await _context.Users
            .Where(u => u.Id == user.Id)
            .FirstOrDefaultAsync()
            ?? throw new NotFoundError("User not found");

            efUser.Password = user.Hash;
            efUser.Salt = user.Salt;
        }

    }
}