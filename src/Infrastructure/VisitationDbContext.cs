using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class VisitationDbContext : DbContext
    {
        public VisitationDbContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }

    }
}
