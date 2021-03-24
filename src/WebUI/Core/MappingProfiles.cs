using Application.Dtos;
using AutoMapper;
using WebUI.Models;

namespace WebUI.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<VisitCreateModel, VisitDTO>();
            CreateMap<VisitUpdateModel, VisitDTO>();

            CreateMap<VisitDTO, VisitUpdateModel>()
                .ForMember(x => x.AccountName, opt => opt.MapFrom(src => src.Account.Name));

            CreateMap<VisitDTO, VisitListModel>()
                .ForMember(x => x.IntendedDate, opt => opt.MapFrom(src => (src.IntendedDate).ToString("dd.MM.yyyy")))
                .ForMember(x => x.VisitDate, opt => opt.MapFrom(src => src.VisitDate.HasValue ? (src.VisitDate.Value).ToString("dd.MM.yyyy") : "-"))
                .ForMember(x => x.UserFullName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(x => x.AccountName, opt => opt.MapFrom(src => src.Account.Name));

        }
    }
}
