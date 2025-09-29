namespace skterminal_fuel_skids_api.Models
{
  public class TrainTag
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool Enabled { get; set; } = true;
    public DateTimeOffset CreationDate { get; set; } = DateTime.UtcNow;
    public Guid TrainId { get; set; }
    public Train Trains { get; set; } = null!;
    public Guid TagId { get; set; }
    public Tag Tags { get; set; } = null!;
  }
}
