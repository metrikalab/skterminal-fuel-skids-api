using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using skterminal_fuel_skids_api.Models;
using skterminal_fuel_skids_api.Data.ConstantData.ProductsData;

namespace skterminal_fuel_skids_api.Configurations.Databases.DatabaseTables
{
  public class ProductConfiguration : IEntityTypeConfiguration<Product>
  {
    public void Configure(EntityTypeBuilder<Product> builder)
    {
      builder
        .Property(p => p.Id)
        .HasDefaultValueSql("gen_random_uuid()");
      builder
        .Property(p => p.Enabled)
        .IsRequired()
        .HasDefaultValueSql("TRUE");
      builder
        .Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(100);
      builder
          .Property(p => p.Description)
          .IsRequired()
          .HasMaxLength(300);
      builder
        .Property(p => p.CreationDate)
        .IsRequired()
        .HasDefaultValueSql("NOW()");

      builder.HasData(
        new Product
        {
          Id = new Guid(DefaultProductsIds.ASFALTO),
          Name = "Asfalto",
          Description = "Asfalto",
          TagValue = 1
        },
        new Product
        {
          Id = new Guid(DefaultProductsIds.GASOLIO),
          Name = "Gasolio",
          Description = "Gasolio",
          TagValue = 2
        }
      );
    }
  }
}
