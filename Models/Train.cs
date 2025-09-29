namespace skterminal_fuel_skids_api.Models
{
  public class Train
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Tag { get; set; } = null!;
    public string Hub { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.UtcNow;
    public bool Enabled { get; set; } = true;
    public Guid? SkidId { get; set; }
    public Skid? Skid { get; set; }
    //public Guid? InstallationId { get; set; }
    //public Installation? Installations { get; set; }
    public IEnumerable<SkidHourlyReportByTrain>? SkidHourlyReportByTrainList { get; set; }
    public IEnumerable<TrainTag>? TrainTagsList { get; set; }
  }
}
