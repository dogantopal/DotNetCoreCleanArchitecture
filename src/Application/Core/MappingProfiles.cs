using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<Visit, VisitDTO>().ReverseMap();
        }
    }
}
