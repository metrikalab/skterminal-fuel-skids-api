using Microsoft.EntityFrameworkCore;
using skterminal_fuel_skids_api.Configurations.Databases.DatabaseTables;
using skterminal_fuel_skids_api.Models;

namespace skterminal_fuel_skids_api.Configurations.Databases
{
  public class DataContextEntityFramework : DbContext
  {
    public DataContextEntityFramework(DbContextOptions options) : base(options)
    {
    }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Skid> Skids { get; set; }
    public virtual DbSet<SkidHourlyReportByTrain> SkidHourlyReportByTrains { get; set; }
    public virtual DbSet<SkidHourlyReport> SkidHourlyReports { get; set; }
    public virtual DbSet<SkidTag> SkidTags { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    public virtual DbSet<Train> Trains { get; set; }
    public virtual DbSet<TrainTag> TRainTags { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasDefaultSchema("public");
      modelBuilder.ApplyConfiguration(new ProductConfiguration());
      modelBuilder.ApplyConfiguration(new SkidConfiguration());
      modelBuilder.ApplyConfiguration(new SkidHourlyReportConfiguration());
      modelBuilder.ApplyConfiguration(new SkidHourlyReportByTrainConfiguration());
      modelBuilder.ApplyConfiguration(new SkidTagConfiguration());
      modelBuilder.ApplyConfiguration(new TagConfiguration());
      modelBuilder.ApplyConfiguration(new TrainConfiguration());
      modelBuilder.ApplyConfiguration(new TrainTagConfiguration());
    }
  }
}
