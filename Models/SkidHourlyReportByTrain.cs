namespace skterminal_fuel_skids_api.Models
{
  public class SkidHourlyReportByTrain
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public double? AverageFactorK { get; set; }
    public double? AverageMF { get; set; }
    public double? StartGrossTotalizer { get; set; }
    public double? EndGrossTotalizer { get; set; }
    public double? LineVolume { get; set; }
    public double? GrossVolume { get; set; }
    public double? NetVolume { get; set; }
    public double? Mass { get; set; }
    public double? AverageTemp { get; set; }
    public double? AveragePres { get; set; }
    public double? AverageTempDens { get; set; }
    public double? AveragePresDens { get; set; }
    public double? AverageObservedDensity { get; set; }
    public double? AverageCorrectedDensity { get; set; }
    public double? AverageFlow { get; set; }
    public double? AverageCTL { get; set; }
    public double? AverageCPL { get; set; }
    public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.UtcNow;
    public bool Enabled { get; set; } = true;
    public Guid? SkidHourlyReportId { get; set; }
    public SkidHourlyReport? SkidHourlyReport { get; set; }
    public Guid? TrainId { get; set; }
    public Train? Train { get; set; }
    //public Guid? InstallationId { get; set; }
    //public Installation? Installations { get; set; }
  }
}
