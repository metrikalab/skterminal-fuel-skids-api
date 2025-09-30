using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
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

   
    [JsonPropertyName("valoresGeneralesTagList")]
    [JsonPropertyOrder(1)]
      public Dictionary<string, GetTagDetailDto> ValoresGeneralesTagList { get; set; } = new();

    
    [JsonPropertyName("operationTagList")]
    [JsonPropertyOrder(2)]
    public Dictionary<string, GetTagDetailDto> OperationTagList { get; set; } = new();
  }
}
