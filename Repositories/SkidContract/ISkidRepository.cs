using skterminal_fuel_skids_api.Models;
using skterminal_fuel_skids_api.Repositories.GenericContract;

namespace skterminal_fuel_skids_api.Repositories.SkidContract
{
  public interface ISkidRepository : IGenericRepository<Skid>
  {
    Task<IEnumerable<Skid>> GetAllSkidsWithTagsAsync();
    Task<bool> IsThereAnotherSkid(string skidTag);
  }
}
