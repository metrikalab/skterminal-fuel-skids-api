using AutoMapper;
using Microsoft.EntityFrameworkCore;
using skterminal_fuel_skids_api.Configurations.Databases;
using skterminal_fuel_skids_api.Models;
using skterminal_fuel_skids_api.Repositories.GenericContract;

namespace skterminal_fuel_skids_api.Repositories.SkidContract
{
  public class SkidRepository : GenericRepository<Skid>, ISkidRepository
  {
    private readonly DataContextEntityFramework _contextEntityFramework;
    private readonly IMapper _mapper;

    public SkidRepository(DataContextEntityFramework contextEntityFramework, IMapper mapper)
      : base(contextEntityFramework, mapper)
    {
      _contextEntityFramework = contextEntityFramework;
      _mapper = mapper;
    }

    public async Task<IEnumerable<Skid>> GetAllSkidsWithTagsAsync()
    {
      var skids = await _contextEntityFramework.Skids
        .Include(s => s.SkidTagsList)
          .ThenInclude(st => st.Tags)
        .AsNoTracking()
        .OrderByDescending(s => s.Order)
        .ToListAsync();

      foreach (var skid in skids)
      {
        skid.SkidTagsList = skid.SkidTagsList?
          .OrderBy(st => st.Tags.Order)
          .ToList();
      }

      return skids;
    }

    public async Task<bool> IsThereAnotherSkid(string skidTag)
    {
      try
      {
        return await _contextEntityFramework.Skids
          .AnyAsync(s => s.Tag.Equals(skidTag) && s.Enabled == true);
      }
      catch (Exception ex)
      {
        throw new InvalidOperationException($"Error al verificar si existe otro skid con tag: {skidTag}", ex);
      }
    }
  }
}
