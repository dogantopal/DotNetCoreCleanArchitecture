using Application.Contracts;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Concretes
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AccountDTO>> GetAccountsAsync()
        {
            var accounts = await _unitOfWork.Accounts.GetAllAsync();

            var output = _mapper.Map<List<AccountDTO>>(accounts);

            return output;
        }
    }
}
