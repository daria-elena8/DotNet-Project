using DotnetProjectAPI.Models;
using DotnetProjectAPI.Models.DTOs;
using AutoMapper;

namespace DotnetProjectAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Visit, VisitDto>()
                .ForMember(dest => dest.placeId, opt => opt.MapFrom(src => src.place.id))
                .ForMember(dest => dest.userId, opt => opt.MapFrom(src => src.user.id))
                .ReverseMap()
                .ForMember(dest => dest.place, opt => opt.Ignore())
                .ForMember(dest => dest.user, opt => opt.Ignore());

            CreateMap<Place, PlaceDto>().ReverseMap();

            CreateMap<Like, LikeDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.userId))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.placeId))
                .ReverseMap()
                .ForMember(dest => dest.visit, opt => opt.Ignore()) 
                .ForMember(dest => dest.user, opt => opt.Ignore());

            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.userId))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.placeId))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.content))
                .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.timestamp))
                .ReverseMap()
                .ForMember(dest => dest.visit, opt => opt.Ignore()) 
                .ForMember(dest => dest.user, opt => opt.Ignore());

            CreateMap<PlaceCreateDto, Place>();
            CreateMap<PlaceDto, Place>();
            CreateMap<Place, PlaceDto>();

        }
    }
}
