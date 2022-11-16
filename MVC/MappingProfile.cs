
using AutoMapper;
using Entities.Dtos;
using GigHub.Models;

namespace JWT
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>()
                .ForMember(u => u.UserName,
                opt => opt.MapFrom(x => x.Email));
        }
    }
}
