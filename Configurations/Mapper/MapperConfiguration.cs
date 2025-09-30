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
      // Skid -> GetSkidDetailDto (las listas se rellenan en el servicio)
      CreateMap<Skid, GetSkidDetailDto>()
        .ForMember(d => d.ParameterTagList, opt => opt.Ignore())
        .ForMember(d => d.OperationTagList, opt => opt.Ignore());

      // Tag -> GetTagDetailDto
      CreateMap<Tag, GetTagDetailDto>();
    }
  }
}
