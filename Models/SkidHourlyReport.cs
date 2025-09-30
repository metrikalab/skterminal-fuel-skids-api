namespace skterminal_fuel_skids_api.Models
{
  public class SkidHourlyReport
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Folio { get; set; } = null!;
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public double AcumMass { get; set; }
    public double AcumVolNatural { get; set; }
    public double AcumVolCondBase { get; set; }
    public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.UtcNow;
    public bool Enabled { get; set; } = true;
    public Guid? SkidId { get; set; }
    public Skid? Skid { get; set; }
    public Guid? ProductId { get; set; }
    public Product? Product { get; set; }
    //public Guid? InstallationId { get; set; }
    //public Installation? Installations { get; set; }
    public IEnumerable<SkidHourlyReportByTrain>? SkidHourlyReportByTrainList { get; set; }
  }
}
