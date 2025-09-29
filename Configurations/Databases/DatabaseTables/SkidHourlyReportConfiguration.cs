using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using skterminal_fuel_skids_api.Models;

namespace skterminal_fuel_skids_api.Configurations.Databases.DatabaseTables
{
  public class SkidHourlyReportConfiguration : IEntityTypeConfiguration<SkidHourlyReport>
  {
    public void Configure(EntityTypeBuilder<SkidHourlyReport> builder)
    {
      builder
          .Property(shr => shr.Id)
          .HasDefaultValueSql("gen_random_uuid()");
      builder
          .Property(shr => shr.Folio)
          .IsRequired()
          .HasMaxLength(128);
      builder
          .Property(shr => shr.StartDate)
          .IsRequired();
      builder
          .Property(shr => shr.EndDate)
          .IsRequired();
      builder
          .Property(shr => shr.AcumMass)
          .IsRequired();
      builder
          .Property(shr => shr.AcumVolNatural)
          .IsRequired();
      builder
          .Property(shr => shr.AcumVolCondBase)
          .IsRequired();
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
