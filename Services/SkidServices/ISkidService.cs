using skterminal_fuel_skids_api.Dtos.SkidDtos;

namespace skterminal_fuel_skids_api.Services.SkidServices
{
  public interface ISkidService
  {
    Task<IEnumerable<GetSkidDetailDto>> GetSkidDetailsAsync();
  }
}
