namespace skterminal_fuel_skids_api.Configurations.CustomHttpResponses
{
  public class UnauthorizedException : ApplicationException
  {
    public UnauthorizedException(string message) : base(message)
    {
    }
  }
}
