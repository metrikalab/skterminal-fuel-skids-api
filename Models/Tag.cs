namespace skterminal_fuel_skids_api.Models
{
  public class Tag
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string TagName { get; set; } = null!;
    public string? Description { get; set; }
    public string? MeasurementUnit { get; set; }
    public double FloatingPrecision { get; set; }
    public string DataType { get; set; } = null!;
    public int? Order { get; set; }
    public int? Display { get; set; } // Si es 0 aparece solo en pantalla de Detalle de Llenaderas y si es 1 aparece en detelle de llenaderas y también en pantalla de inicio.
    public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.UtcNow;
    public bool Enabled { get; set; } = true;
    //public Guid? InstallationId { get; set; }
    //public Installation? Installations { get; set; }
    //public IEnumerable<TankTag>? TankTagsList { get; set; }
    public IEnumerable<TrainTag>? TrainTagsList { get; set; }
    public IEnumerable<SkidTag>? SkidTagsList { get; set; }
    //public IEnumerable<FillerTag>? FillerTagsList { get; set; }
    //public IEnumerable<DownloaderTag>? DownloaderTagsList { get; set; }
  }
}
