

namespace school_api.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUsersRepository Users{ get; }

        Task TransactionAsync(Func<Task> action);
        Task<int> Save();
    }
}