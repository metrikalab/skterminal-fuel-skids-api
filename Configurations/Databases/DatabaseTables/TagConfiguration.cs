using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using skterminal_fuel_skids_api.Data.ConstantData.TagsData;
using skterminal_fuel_skids_api.Models;

namespace skterminal_fuel_skids_api.Configurations.Databases.DatabaseTables
{
  public class TagConfiguration : IEntityTypeConfiguration<Tag>
  {
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
      builder
        .Property(t => t.Id)
        .HasDefaultValueSql("gen_random_uuid()");
      builder
        .Property(t => t.TagName)
        .IsRequired()
        .HasMaxLength(50);
      builder
        .Property(t => t.Description)
        .HasMaxLength(150);
      builder
        .Property(t => t.DataType)
        .IsRequired()
        .HasMaxLength(200);
      builder
        .Property(t => t.MeasurementUnit)
        .HasMaxLength(100);
      builder
        .Property(t => t.CreationDate)
        .IsRequired()
        .HasDefaultValueSql("NOW()");
      builder
        .Property(t => t.Enabled)
        .IsRequired()
        .HasDefaultValueSql("TRUE");

      builder.HasData(
        new Tag
        {
          Id = Guid.Parse(DefaultTag.DENSIDAD),
          TagName = "DENSIDAD",
          DataType = "Valores Generales",
          FloatingPrecision = 2,
          MeasurementUnit = "Kg/m³",
          Display = 0,
          Order = 1,
          Enabled = true,
          CreationDate = DateTimeOffset.UtcNow
        },
        new Tag
        {
          Id = Guid.Parse(DefaultTag.FLUJO_TREN1),
          TagName = "FLUJO_TREN1",
          DataType = "Parámetro de operación",
          FloatingPrecision = 2,
          MeasurementUnit = "L/m",
          Display = 1,
          Order = 2,
          Enabled = true,
          CreationDate = DateTimeOffset.UtcNow
        },
        new Tag
        {
          Id = Guid.Parse(DefaultTag.FLUJO_TREN2),
          TagName = "FLUJO_TREN2",
          DataType = "Parámetro de operación",
          FloatingPrecision = 2,
          MeasurementUnit = "L/m",
          Display = 1,
          Order = 3,
          Enabled = true,
          CreationDate = DateTimeOffset.UtcNow
        },
        new Tag
        {
          Id = Guid.Parse(DefaultTag.PRESION_DENS),
          TagName = "PRESION_DENS",
          DataType = "Valores Generales",
          FloatingPrecision = 2,
          MeasurementUnit = "Kg/cm²",
          Display = 0,
          Order = 4,
          Enabled = true,
          CreationDate = DateTimeOffset.UtcNow
        },
        new Tag
        {
          Id = Guid.Parse(DefaultTag.PRESION_TREN1),
          TagName = "PRESION_TREN1",
          DataType = "Parámetro de operación",
          FloatingPrecision = 2,
          MeasurementUnit = "Kg/cm²",
          Display = 0,
          Order = 5,
          Enabled = true,
          CreationDate = DateTimeOffset.UtcNow
        },
        new Tag
        {
          Id = Guid.Parse(DefaultTag.PRESION_TREN2),
          TagName = "PRESION_TREN2",
          DataType = "Parámetro de operación",
          FloatingPrecision = 2,
          MeasurementUnit = "Kg/cm²",
          Display = 0,
          Order = 6,
          Enabled = true,
          CreationDate = DateTimeOffset.UtcNow
        },
        new Tag
        {
          Id = Guid.Parse(DefaultTag.TEMP_DENS),
          TagName = "TEMP_DENS",
          DataType = "Valores Generales",
          FloatingPrecision = 2,
          MeasurementUnit = "°C",
          Display = 0,
          Order = 7,
          Enabled = true,
          CreationDate = DateTimeOffset.UtcNow
        },
        new Tag
        {
          Id = Guid.Parse(DefaultTag.TEMP_TREN1),
          TagName = "TEMP_TREN1",
          DataType = "Parámetro de operación",
          FloatingPrecision = 2,
          MeasurementUnit = "°C",
          Display = 0,
          Order = 8,
          Enabled = true,
          CreationDate = DateTimeOffset.UtcNow
        },
        new Tag
        {
          Id = Guid.Parse(DefaultTag.TEMP_TREN2),
          TagName = "TEMP_TREN2",
          DataType = "Parámetro de operación",
          FloatingPrecision = 2,
          MeasurementUnit = "°C",
          Display = 0,
          Order = 9,
          Enabled = true,
          CreationDate = DateTimeOffset.UtcNow
        }
      );
    }
  }
}
