namespace skterminal_fuel_skids_api.Configurations.CustomHttpResponses
{
  public class BadRequestException
  : ApplicationException
  {
    public BadRequestException(string message) : base(message)
    {

    }
  }
}
