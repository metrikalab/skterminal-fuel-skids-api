using skterminal_fuel_skids_api.Models;

namespace skterminal_fuel_skids_api.Validators.SkidValidators
{
  public interface ISkidValidator
  {
    bool IsSkidWithDetailsListValid(IEnumerable<Skid>? skids);
    void IsAddSkidValid(bool skidAlreadyExists);
  }
}
