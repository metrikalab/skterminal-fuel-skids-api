using System.ComponentModel.DataAnnotations;
using skterminal_fuel_skids_api.Dtos.TagDtos;

namespace skterminal_fuel_skids_api.Dtos.SkidDtos
{
  public class GetSkidDetailDto
  {
    [Required]
    public Guid Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Tag { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string Hub { get; set; } = null!;

    [StringLength(150)]
    public string? Description { get; set; }

    public int? Order { get; set; }

    [Required]
    public bool Enabled { get; set; }

    [Required]
    public DateTimeOffset CreationDate { get; set; }

    public Dictionary<string, GetTagDetailDto> ParameterTagList { get; set; } = new();
    public Dictionary<string, GetTagDetailDto> OperationTagList { get; set; } = new();
  }
}
