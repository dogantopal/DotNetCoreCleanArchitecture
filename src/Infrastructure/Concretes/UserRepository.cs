using Domain.Entities;
using Infrastructure.Contracts;

namespace Infrastructure.Concretes
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(VisitationDbContext context)
          : base(context)
        {
        }
    }
}
