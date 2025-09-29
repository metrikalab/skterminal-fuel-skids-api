using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace skterminal_fuel_skids_api.Configurations.Controllers
{
  public class ValidateModelAttribute : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      if (context.ModelState.IsValid) return;

      var errors = context.ModelState
          .Where(x => x.Value.Errors.Count > 0)
          .Select(x => new { Field = x.Key, Message = x.Value.Errors.First().ErrorMessage })
          .ToArray();


      // context.Result = new BadRequestResult();

      context.Result = new BadRequestObjectResult(new
      {
        Success = false,
        StatusCode = 400,
        Errors = errors
      });
    }
  }
}
