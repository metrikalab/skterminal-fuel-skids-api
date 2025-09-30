using System.Diagnostics;

namespace skterminal_fuel_skids_api.Models
{
  public class Skid
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Tag { get; set; } = null!;
    public string Hub { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.UtcNow;
    public bool Enabled { get; set; } = true;
    //public Guid? LineTypeId { get; set; }
    //public LineType? LineType { get; set; }
    public Guid? ProductId { get; set; }
    public Product? Product { get; set; }
    //public Guid? InstallationId { get; set; }
    //public Installation? Installations { get; set; }
    public IEnumerable<SkidHourlyReport>? SkidHourlyReportList { get; set; }
    public IEnumerable<Train>? TrainList { get; set; }
    public IEnumerable<SkidTag>? SkidTagsList { get; set; }
    public int? Order { get; set; }
  }
}
