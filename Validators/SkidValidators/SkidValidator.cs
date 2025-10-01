using skterminal_fuel_skids_api.Configurations.CustomHttpResponses;
using skterminal_fuel_skids_api.Models;
using skterminal_fuel_skids_api.Utils.Validations;

namespace skterminal_fuel_skids_api.Validators.SkidValidators
{
  public class SkidValidator : ISkidValidator
  {
    public bool IsSkidWithDetailsListValid(IEnumerable<Skid>? skids)
    {
      if (!skids.IsDifferentToNull() || !skids!.Any())
        throw new NotFoundException("No se encontró ningún skid.");

      return true;
    }

    public void IsAddSkidValid(bool skidAlreadyExists)
    {
      if (skidAlreadyExists)
        throw new BadRequestException("Ya existe un skid con ese tag.");
    }
  }
}
