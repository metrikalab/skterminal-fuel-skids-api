using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using skterminal_fuel_skids_api.Data.ConstantData.ProductsData;
using skterminal_fuel_skids_api.Data.ConstantData.SkidsData;
using skterminal_fuel_skids_api.Models;

namespace skterminal_fuel_skids_api.Configurations.Databases.DatabaseTables
{
  public class SkidConfiguration : IEntityTypeConfiguration<Skid>
  {
    public void Configure(EntityTypeBuilder<Skid> builder)
    {
      builder
          .Property(s => s.Id)
          .HasDefaultValueSql("gen_random_uuid()");
      builder
          .Property(s => s.Tag)
          .IsRequired()
          .HasMaxLength(128);
      builder
          .Property(s => s.Description)
          .IsRequired()
          .HasMaxLength(100);
      builder
          .Property(s => s.CreationDate)
          .IsRequired()
          .HasDefaultValueSql("NOW()");
      builder
          .Property(s => s.Enabled)
          .IsRequired()
          .HasDefaultValueSql("TRUE");

      // Seed
      builder.HasData(
        new Skid
        {
          Id = Guid.Parse(DefaultSkid.PS),
          Tag = "PS",
          Hub = "",
          Description = "Patín de Entrega",
          CreationDate = DateTimeOffset.Parse("2025-07-21 19:45:10.924489+00"),
          Enabled = true,
          ProductId = Guid.Parse(DefaultProductsIds.ASFALTO)
        },
        new Skid
        {
          Id = Guid.Parse(DefaultSkid.PE),
          Tag = "PE",
          Hub = "",
          Description = "Patín de Recepción",
          CreationDate = DateTimeOffset.Parse("2025-06-30 06:00:00+00"),
          Enabled = true,
          ProductId = Guid.Parse(DefaultProductsIds.ASFALTO)
        }
      );
    }
  }
}
