using Application.Contracts;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Concretes
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetUsersAsync()
        {
            var employees = await _unitOfWork.Users.GetAllAsync();

            var output = _mapper.Map<List<UserDTO>>(employees);

            return output;
        }
    }
}
