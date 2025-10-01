using System.ComponentModel.DataAnnotations;

namespace skterminal_fuel_skids_api.Dtos.TagDtos
{
  public class GetTagDetailDto
  {
    [Required]
    public Guid Id { get; set; }

    [Required]
    [StringLength(50)]
    public string TagName { get; set; } = null!;

    [StringLength(150)]
    public string? Description { get; set; }

    [StringLength(100)]
    public string? MeasurementUnit { get; set; }

    [Required]
    public double FloatingPrecision { get; set; }

    [Required]
    [StringLength(200)]
    public string DataType { get; set; } = null!;

    public int? Order { get; set; }

    public int? Display { get; set; }

    [Required]
    public bool Enabled { get; set; }

    [Required]
    public DateTimeOffset CreationDate { get; set; }
  }
}
