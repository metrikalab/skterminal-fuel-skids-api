namespace skterminal_fuel_skids_api.Configurations.CustomHttpResponses
{
  public class KeyValueDuplicatedException : ApplicationException
  {
    public KeyValueDuplicatedException(string message) : base(message)
    {
    }

    public KeyValueDuplicatedException(string name, object value) : base($"{name} con el valor ({value}) ya existe en la base de datos")
    {
    }
  }
}
