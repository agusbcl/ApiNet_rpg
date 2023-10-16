using ApiNet.Dtos.Power;
using ApiNet.Dtos.RpgClass;

namespace ApiNet
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>()
                .ForMember(dest => dest.RpgClass, src => src.MapFrom(x => x.RpgClass));
            CreateMap<AddCharacterDto, Character>();
            CreateMap<UpdateCharacterDto, Character>();
            CreateMap<Character, ShortDescriptionDto>();
            CreateMap<RpgClass, RpgClassDto>().ReverseMap();
            CreateMap<Power, PowerDto>().ReverseMap();
        }
    }
}
