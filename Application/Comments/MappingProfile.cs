
using System.Linq;
using AutoMapper;
using Domain;

namespace Application.Comments
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.Username, o => o.MapFrom(s => s.Author.UserName))
                .ForMember(dest => dest.DisplayName, o => o.MapFrom(s => s.Author.DisplayName))
                .ForMember(dest => dest.Image, o => o.MapFrom(
                    s => s.Author.Photos.FirstOrDefault(ph => ph.IsMain).Url));
        }
    }
}