using System.Linq;
using AutoMapper;
using Domain;

namespace Application.Activities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Activity, ActivityDto>();
            CreateMap<UserActivity, AttendeeDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(s => s.AppUser.UserName))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(s => s.AppUser.DisplayName))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(s =>
                s.AppUser.Photos.FirstOrDefault(ph => ph.IsMain).Url))
                .ForMember(d => d.Following, o => o.MapFrom<FollowingResolver>());
        }
    }
}