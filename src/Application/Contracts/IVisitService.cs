using Application.Dtos;
using Infrastructure.Core;
using Infrastructure.SearchParams;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IVisitService
    {
        Task CreateAsync(VisitDTO model);
        Task<VisitDTO> GetAsync(int id);
        Task UpdateAsync(VisitDTO model);
        Task<Pagination<VisitDTO>> GetAllAsync(VisitSearchParams visitSearchParams);
        Task DeleteAsync(int id);
    }
}
