using AutoMapper;
using skterminal_fuel_skids_api.Dtos.SkidDtos;
using skterminal_fuel_skids_api.Dtos.TagDtos;
using skterminal_fuel_skids_api.Repositories.SkidContract;
using skterminal_fuel_skids_api.Validators.SkidValidators;

namespace skterminal_fuel_skids_api.Services.SkidServices
{
  public class SkidService : ISkidService
  {
    private readonly ISkidRepository _skidRepository;
    private readonly ISkidValidator _skidValidator;
    private readonly IMapper _mapper;

    public SkidService(ISkidRepository skidRepository, ISkidValidator skidValidator, IMapper mapper)
    {
      _skidRepository = skidRepository;
      _skidValidator = skidValidator;
      _mapper = mapper;
    }

    public async Task<IEnumerable<GetSkidDetailDto>> GetSkidDetailsAsync()
    {
      var skids = await _skidRepository.GetAllSkidsWithTagsAsync();
      _skidValidator.IsSkidWithDetailsListValid(skids);

      var result = skids.Select(s =>
      {
        var dto = new GetSkidDetailDto
        {
          Id = s.Id,
          Tag = s.Tag,
          Hub = s.Hub,
          Description = s.Description,
          Order = s.Order,
          Enabled = s.Enabled,
          CreationDate = s.CreationDate
        };

        var tags = s.SkidTagsList?
          .Where(st => st?.Tags != null)
          .Select(st => st!.Tags!)
          .OrderBy(t => t.Order ?? int.MaxValue)
          .ToList();

        if (tags != null)
        {
          foreach (var t in tags)
          {
            var tagDto = new GetTagDetailDto
            {
              Id = t.Id,
              TagName = t.TagName,
              Description = t.Description,
              MeasurementUnit = t.MeasurementUnit,
              FloatingPrecision = t.FloatingPrecision,
              DataType = t.DataType,
              Order = t.Order,
              Display = t.Display,
              Enabled = t.Enabled,
              CreationDate = t.CreationDate
            };

            var key = t.TagName; 

            if (t.DataType == "Valores Generales")
              dto.GeneralValuesTagList[key] = tagDto;
            else if (t.DataType == "Parámetro de operación")
              dto.OperationTagList[key] = tagDto;
            else
              dto.OperationTagList[key] = tagDto;
          }
        }

        return dto;
      }).ToList();

      return result;
    }
  }
}
