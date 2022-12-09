using Application.Identity.Dtos;
using AutoMapper;

namespace Infrastructure.Identity
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<AppUser, UserDto>().ReverseMap();
            CreateMap<RegisterDto, AppUser>();
        }
    }
}
