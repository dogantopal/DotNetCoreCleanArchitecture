using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUsersAsync();
    }
}
