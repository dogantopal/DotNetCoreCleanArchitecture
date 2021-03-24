using System;
using System.Threading.Tasks;

namespace Infrastructure.Contracts
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IAccountRepository Accounts { get; }
        IUserRepository Users { get; }
        IVisitRepository Visits { get; }
        Task<int> CompleteAsync();
    }
}
