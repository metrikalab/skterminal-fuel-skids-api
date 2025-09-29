namespace skterminal_fuel_skids_api.Models
{
  public class SkidTag
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool Enabled { get; set; } = true;
    public DateTimeOffset CreationDate { get; set; } = DateTime.UtcNow;
    public Guid SkidId { get; set; }
    public Skid Skids { get; set; } = null!;
    public Guid TagId { get; set; }
    public Tag Tags { get; set; } = null!;
  }
}
