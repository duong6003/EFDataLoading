using AutoMapper;
using Web.Entities;
using Web.EntitiesDTO;

namespace Web.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddStudent,Student>();
        CreateMap<AddPrize,Prize>();
        CreateMap<AddPrizeItem,PrizeItem>();
    }
}