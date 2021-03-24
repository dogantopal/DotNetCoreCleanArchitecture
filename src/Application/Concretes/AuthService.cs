using Application.Contracts;
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Contracts;
using Infrastructure.Helpers;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concretes
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDTO> LoginAsync(string username, string password)
        {
            var user = await _unitOfWork.Users.GetAsync(x => x.Username == username);

            if (user == null)
                throw new Exception("User not found.");

            if (!PasswordHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new Exception("Username or password is wrong.");

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> RegisterAsync(UserDTO employee, string password, string passwordAgain)
        {
            if (!string.Equals(password, passwordAgain))
                throw new Exception("Passwords not match.");

            byte[] passwordHash, passwordSalt;
            PasswordHelper.CreatePasswordHashAndSalt(password, out passwordHash, out passwordSalt);

            User entity = _mapper.Map<User>(employee);
            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;

            _unitOfWork.Users.Add(entity);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<UserDTO>(entity);
        }
    }
}
