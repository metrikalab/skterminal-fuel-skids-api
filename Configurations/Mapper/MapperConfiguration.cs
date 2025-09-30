using AutoMapper;
using skterminal_fuel_skids_api.Dtos.SkidDtos;
using skterminal_fuel_skids_api.Dtos.TagDtos;
using skterminal_fuel_skids_api.Models;

namespace skterminal_fuel_skids_api.Configurations.Mapper
{
  public class MapperConfiguration : Profile
  {
    public MapperConfiguration()
    {
   
      CreateMap<Skid, GetSkidDetailDto>()
        .ForMember(d => d.ValoresGeneralesTagList, opt => opt.Ignore())
        .ForMember(d => d.OperationTagList, opt => opt.Ignore());

      CreateMap<Tag, GetTagDetailDto>();
    }
  }
}
