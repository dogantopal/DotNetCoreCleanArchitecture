using Infrastructure.Contracts;
using System.Threading.Tasks;

namespace Infrastructure.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VisitationDbContext _context;

        public UnitOfWork(VisitationDbContext context)
        {
            _context = context;
            Accounts = new AccountRepository(_context);
            Users = new UserRepository(_context);
            Visits = new VisitRepository(_context);
        }

        public IAccountRepository Accounts { get; private set; }
        public IUserRepository Users { get; private set; }
        public IVisitRepository Visits { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
