using Domain.Entities;
using Infrastructure.Contracts;

namespace Infrastructure.Concretes
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(VisitationDbContext context)
          : base(context)
        {
        }
    }
}
