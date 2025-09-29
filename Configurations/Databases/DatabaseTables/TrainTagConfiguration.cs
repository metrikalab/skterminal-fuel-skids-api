using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using skterminal_fuel_skids_api.Models;

namespace skterminal_fuel_skids_api.Configurations.Databases.DatabaseTables
{
  public class TrainTagConfiguration : IEntityTypeConfiguration<TrainTag>
  {
    public void Configure(EntityTypeBuilder<TrainTag> builder)
    {
      builder
        .Property(tt => tt.Id)
        .HasDefaultValueSql("gen_random_uuid()");
      builder
        .Property(tt => tt.CreationDate)
        .IsRequired()
        .HasDefaultValueSql("NOW()");
      builder
        .Property(tt => tt.Enabled)
        .IsRequired()
        .HasDefaultValueSql("TRUE");
    }
  }
}
