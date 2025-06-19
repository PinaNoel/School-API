
using Microsoft.EntityFrameworkCore.Storage;
using school_api.Core.Interfaces;
using school_api.Infrastructure.Context;
using school_api.Core.Errors;


namespace school_api.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly SchoolDataBaseContext _context;
        private IDbContextTransaction? _transaction;

        public IUsersRepository Users { get;}


        public UnitOfWork(SchoolDataBaseContext context, IUsersRepository users)
        {
            _context = context;
            Users = users;
        }


        public async Task TransactionAsync(Func<Task> action)
        {
            _transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                await action();
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await _transaction.RollbackAsync();
                // throw new Exception("", ex);
                throw new DataBaseError(ex);
            }
        }


        public async Task<int> Save() => await _context.SaveChangesAsync();


        public void Dispose()
        {
            _context.Dispose();
        }
    }
} 