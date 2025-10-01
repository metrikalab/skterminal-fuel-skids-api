using Microsoft.AspNetCore.Mvc;
using skterminal_fuel_skids_api.Configurations.CustomHttpResponses;
using skterminal_fuel_skids_api.Dtos.SkidDtos;
using skterminal_fuel_skids_api.Services.SkidServices;

namespace skterminal_fuel_skids_api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class SkidController : ControllerBase
  {
    private readonly ISkidService _skidService;

    public SkidController(ISkidService skidService)
    {
      _skidService = skidService;
    }

    [HttpGet("GetSkidsWithDetails")]
    [ProducesResponseType(typeof(IEnumerable<GetSkidDetailDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorMessage), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<GetSkidDetailDto>>> GetSkidsWithDetails()
    {
      var skids = await _skidService.GetSkidDetailsAsync();
      return Ok(skids);
    }
  }
}
