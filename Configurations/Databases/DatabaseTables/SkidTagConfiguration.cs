using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using skterminal_fuel_skids_api.Models;

namespace skterminal_fuel_skids_api.Configurations.Databases.DatabaseTables
{
  public class SkidTagConfiguration : IEntityTypeConfiguration<SkidTag>
  {
    public void Configure(EntityTypeBuilder<SkidTag> builder)
    {
      builder
        .Property(st => st.Id)
        .HasDefaultValueSql("gen_random_uuid()");
      builder
        .Property(st => st.CreationDate)
        .IsRequired()
        .HasDefaultValueSql("NOW()");
      builder
        .Property(st => st.Enabled)
        .IsRequired()
        .HasDefaultValueSql("TRUE");
    }
  }
}
