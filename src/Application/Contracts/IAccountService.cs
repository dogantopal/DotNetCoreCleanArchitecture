using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IAccountService
    {
        Task<List<AccountDTO>> GetAccountsAsync();
    }
}
