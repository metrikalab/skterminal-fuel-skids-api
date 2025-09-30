using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using skterminal_fuel_skids_api.Data.ConstantData.SkidsData;
using skterminal_fuel_skids_api.Data.ConstantData.TrainsData;
using skterminal_fuel_skids_api.Models;

namespace skterminal_fuel_skids_api.Configurations.Databases.DatabaseTables
{
  public class TrainConfiguration : IEntityTypeConfiguration<Train>
  {
    public void Configure(EntityTypeBuilder<Train> builder)
    {
      builder
          .Property(t => t.Id)
          .HasDefaultValueSql("gen_random_uuid()");
      builder
          .Property(t => t.Tag)
          .IsRequired()
          .HasMaxLength(128);
      builder
          .Property(t => t.Description)
          .IsRequired()
          .HasMaxLength(100);
      builder
          .Property(t => t.CreationDate)
          .IsRequired()
          .HasDefaultValueSql("NOW()");
      builder
          .Property(t => t.Enabled)
          .IsRequired()
          .HasDefaultValueSql("TRUE");

      // Seed
      builder.HasData(
        new Train
        {
          Id = Guid.Parse(DefaultTrain.T110),
          Tag = "T-110",
          Hub = "",
          Description = "Tren 110",
          CreationDate = DateTimeOffset.Parse("2025-07-21 19:46:54.059233+00"),
          Enabled = true,
          SkidId = Guid.Parse(DefaultSkid.PS)
        },
        new Train
        {
          Id = Guid.Parse(DefaultTrain.T113),
          Tag = "T-113",
          Hub = "",
          Description = "Tren 113",
          CreationDate = DateTimeOffset.Parse("2025-07-21 19:50:13.496846+00"),
          Enabled = true,
          SkidId = Guid.Parse(DefaultSkid.PS)
        },
        new Train
        {
          Id = Guid.Parse(DefaultTrain.T112),
          Tag = "T-112",
          Hub = "",
          Description = "Tren 112",
          CreationDate = DateTimeOffset.Parse("2025-07-21 19:49:38.521672+00"),
          Enabled = true,
          SkidId = Guid.Parse(DefaultSkid.PS)
        },
        new Train
        {
          Id = Guid.Parse(DefaultTrain.T101),
          Tag = "T-101",
          Hub = "",
          Description = "Tren 101",
          CreationDate = DateTimeOffset.Parse("2025-07-16 23:00:09.018281+00"),
          Enabled = true,
          SkidId = Guid.Parse(DefaultSkid.PE)
        },
        new Train
        {
          Id = Guid.Parse(DefaultTrain.T100),
          Tag = "T-100",
          Hub = "",
          Description = "Tren 100",
          CreationDate = DateTimeOffset.Parse("2025-07-16 22:59:29.060944+00"),
          Enabled = true,
          SkidId = Guid.Parse(DefaultSkid.PE)
        },
        new Train
        {
          Id = Guid.Parse(DefaultTrain.T111),
          Tag = "T-111",
          Hub = "",
          Description = "Tren 111",
          CreationDate = DateTimeOffset.Parse("2025-07-21 19:48:58.504105+00"),
          Enabled = true,
          SkidId = Guid.Parse(DefaultSkid.PS)
        }
      );
    }
  }
}
