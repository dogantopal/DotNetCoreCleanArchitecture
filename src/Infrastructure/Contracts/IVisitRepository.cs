using Domain.Entities;
using Infrastructure.SearchParams;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Contracts
{
    public interface IVisitRepository : IRepository<Visit>
    {
        Task<List<Visit>> GetAllWithUserAndAccountAsync(VisitSearchParams visitSearchParams);
        Task<Visit> GetVisitWithAccountAsync(int id);
        Task<int> CountAsync(VisitSearchParams visitSearchParams);
    }
}
