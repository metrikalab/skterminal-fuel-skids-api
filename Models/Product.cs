using System.Threading.Tasks;

namespace skterminal_fuel_skids_api.Models
{
  public class Product
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? TagValue { get; set; }
    public bool Enabled { get; set; } = true;
    public DateTimeOffset CreationDate { get; set; } = DateTime.UtcNow;
    public DateTimeOffset? ModificationDate { get; set; }

    //FK 
    //public IEnumerable<Tank>? TanksList { get; set; }
    //public IEnumerable<Operation>? OperationsList { get; set; }
    public IEnumerable<Skid>? SkidsList { get; set; }
    public IEnumerable<SkidHourlyReport>? SkidHourlyReportList { get; set; }
    //public IEnumerable<StockRecord>? StockRecordsList { get; set; }
  }
}
