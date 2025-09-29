using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using skterminal_fuel_skids_api.Models;

namespace skterminal_fuel_skids_api.Configurations.Databases.DatabaseTables
{
  public class SkidHourlyReportByTrainConfiguration : IEntityTypeConfiguration<SkidHourlyReportByTrain>
  {
    public void Configure(EntityTypeBuilder<SkidHourlyReportByTrain> builder)
    {
      builder
          .Property(shr => shr.Id)
          .HasDefaultValueSql("gen_random_uuid()");
      builder
          .Property(shr => shr.CreationDate)
          .IsRequired()
          .HasDefaultValueSql("NOW()");
      builder
          .Property(shr => shr.Enabled)
          .IsRequired()
          .HasDefaultValueSql("TRUE");
    }
  }
}
