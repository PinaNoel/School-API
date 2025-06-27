
using school_api.Core.Entities;


namespace school_api.Core.Interfaces
{
    public interface IUsersRepository
    {
        Task AddUser(User user);
        Task AddStudent(User user);
        Task<User?> GetUserCredentials(string enrollment);
        Task<User?> GetPassword(int id);
        Task ChangePassword(User user);
    }
}