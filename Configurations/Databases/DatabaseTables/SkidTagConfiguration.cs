using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using skterminal_fuel_skids_api.Data.ConstantData.SkidsData;
using skterminal_fuel_skids_api.Data.ConstantData.SkidTagsData;
using skterminal_fuel_skids_api.Data.ConstantData.TagsData;
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

      var created = DateTimeOffset.Parse("2025-08-05 18:00:19+00");

      // Solo se dejan SkidTags cuyos TagId coinciden con DefaultTag.*
      builder.HasData(
        new SkidTag
        {
          Id = Guid.Parse(DefaultSkidTag.ST01),
          Enabled = true,
          CreationDate = created,
          SkidId = Guid.Parse(DefaultSkid.PS),
          TagId = Guid.Parse(DefaultTag.DENSIDAD)
        },
        new SkidTag
        {
          Id = Guid.Parse(DefaultSkidTag.ST02),
          Enabled = true,
          CreationDate = created,
          SkidId = Guid.Parse(DefaultSkid.PE),
          TagId = Guid.Parse(DefaultTag.DENSIDAD)
        },
        new SkidTag
        {
          Id = Guid.Parse(DefaultSkidTag.ST03),
          Enabled = true,
          CreationDate = created,
          SkidId = Guid.Parse(DefaultSkid.PS),
          TagId = Guid.Parse(DefaultTag.FLUJO_TREN1)
        },
        new SkidTag
        {
          Id = Guid.Parse(DefaultSkidTag.ST04),
          Enabled = true,
          CreationDate = created,
          SkidId = Guid.Parse(DefaultSkid.PE),
          TagId = Guid.Parse(DefaultTag.FLUJO_TREN1)
        },
        new SkidTag
        {
          Id = Guid.Parse(DefaultSkidTag.ST05),
          Enabled = true,
          CreationDate = created,
          SkidId = Guid.Parse(DefaultSkid.PS),
          TagId = Guid.Parse(DefaultTag.FLUJO_TREN2)
        },
        new SkidTag
        {
          Id = Guid.Parse(DefaultSkidTag.ST06),
          Enabled = true,
          CreationDate = created,
          SkidId = Guid.Parse(DefaultSkid.PE),
          TagId = Guid.Parse(DefaultTag.FLUJO_TREN2)
        },
        new SkidTag
        {
          Id = Guid.Parse(DefaultSkidTag.ST07),
          Enabled = true,
          CreationDate = created,
          SkidId = Guid.Parse(DefaultSkid.PS),
          TagId = Guid.Parse(DefaultTag.PRESION_DENS)
        },
        new SkidTag
        {
          Id = Guid.Parse(DefaultSkidTag.ST08),
          Enabled = true,
          CreationDate = created,
          SkidId = Guid.Parse(DefaultSkid.PE),
          TagId = Guid.Parse(DefaultTag.PRESION_DENS)
        },
        new SkidTag
        {
          Id = Guid.Parse(DefaultSkidTag.ST09),
          Enabled = true,
          CreationDate = created,
          SkidId = Guid.Parse(DefaultSkid.PS),
          TagId = Guid.Parse(DefaultTag.PRESION_TREN1)
        },
        new SkidTag
        {
          Id = Guid.Parse(DefaultSkidTag.ST10),
          Enabled = true,
          CreationDate = created,
          SkidId = Guid.Parse(DefaultSkid.PE),
          TagId = Guid.Parse(DefaultTag.PRESION_TREN1)
        },
        new SkidTag
        {
          Id = Guid.Parse(DefaultSkidTag.ST11),
          Enabled = true,
          CreationDate = created,
          SkidId = Guid.Parse(DefaultSkid.PS),
          TagId = Guid.Parse(DefaultTag.PRESION_TREN2)
        },
        new SkidTag
        {
          Id = Guid.Parse(DefaultSkidTag.ST12),
          Enabled = true,
          CreationDate = created,
          SkidId = Guid.Parse(DefaultSkid.PE),
          TagId = Guid.Parse(DefaultTag.PRESION_TREN2)
        },
        new SkidTag
        {
          Id = Guid.Parse(DefaultSkidTag.ST13),
          Enabled = true,
          CreationDate = created,
          SkidId = Guid.Parse(DefaultSkid.PS),
          TagId = Guid.Parse(DefaultTag.TEMP_DENS)
        },
        new SkidTag
        {
          Id = Guid.Parse(DefaultSkidTag.ST14),
          Enabled = true,
          CreationDate = created,
          SkidId = Guid.Parse(DefaultSkid.PE),
          TagId = Guid.Parse(DefaultTag.TEMP_DENS)
        },
        new SkidTag
        {
          Id = Guid.Parse(DefaultSkidTag.ST15),
          Enabled = true,
          CreationDate = created,
          SkidId = Guid.Parse(DefaultSkid.PS),
          TagId = Guid.Parse(DefaultTag.TEMP_TREN1)
        },
        new SkidTag
        {
          Id = Guid.Parse(DefaultSkidTag.ST16),
          Enabled = true,
          CreationDate = created,
          SkidId = Guid.Parse(DefaultSkid.PE),
          TagId = Guid.Parse(DefaultTag.TEMP_TREN1)
        },
        new SkidTag
        {
          Id = Guid.Parse(DefaultSkidTag.ST17),
          Enabled = true,
          CreationDate = created,
          SkidId = Guid.Parse(DefaultSkid.PS),
          TagId = Guid.Parse(DefaultTag.TEMP_TREN2)
        },
        new SkidTag
        {
          Id = Guid.Parse(DefaultSkidTag.ST18),
          Enabled = true,
          CreationDate = created,
          SkidId = Guid.Parse(DefaultSkid.PE),
          TagId = Guid.Parse(DefaultTag.TEMP_TREN2)
        }
      );
    }
  }
}
