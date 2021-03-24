using Application.Dtos;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IAuthService
    {
        Task<UserDTO> LoginAsync(string username, string password);
        Task<UserDTO> RegisterAsync(UserDTO employee, string password, string passwordAgain);
    }
}
