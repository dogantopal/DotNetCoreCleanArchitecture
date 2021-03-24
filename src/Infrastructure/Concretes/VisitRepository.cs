using Domain.Entities;
using Infrastructure.Contracts;
using Infrastructure.SearchParams;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Concretes
{
    public class VisitRepository : Repository<Visit>, IVisitRepository
    {
        private readonly VisitationDbContext _context;

        public VisitRepository(VisitationDbContext context)
          : base(context)
        {
            _context = context;
        }

        public async Task<int> CountAsync(VisitSearchParams visitSearchParams)
        {
            var query = _context.Visits.AsQueryable();

            if (visitSearchParams.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == visitSearchParams.UserId.Value);
            }

            if (!string.IsNullOrEmpty(visitSearchParams.Search))
            {
                query = query.Where(x => x.Account.Name.Contains(visitSearchParams.Search));
            }

            var data = await query.CountAsync();

            return data;
        }

        public async Task<List<Visit>> GetAllWithUserAndAccountAsync(VisitSearchParams visitSearchParams)
        {
            var query = _context.Visits
                .Include(x => x.Account)
                .Include(x => x.User).AsQueryable();


            if (visitSearchParams.Status == VisitStatus.Coming)
            {
                query = query.Where(x => !x.VisitDate.HasValue);
            }

            if (visitSearchParams.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == visitSearchParams.UserId.Value);
            }

            if(!string.IsNullOrEmpty(visitSearchParams.Search))
            {
                query = query.Where(x => x.Account.Name.Contains(visitSearchParams.Search));
            }

            var data = await query.Skip(visitSearchParams.Skip).Take(visitSearchParams.Take).ToListAsync();

            return data;
        }

        public async Task<Visit> GetVisitWithAccountAsync(int id)
        {
            var data = await _context.Visits
               .Include(x => x.Account)
               .FirstOrDefaultAsync(x => x.Id == id);

            return data;
        }
    }
}
