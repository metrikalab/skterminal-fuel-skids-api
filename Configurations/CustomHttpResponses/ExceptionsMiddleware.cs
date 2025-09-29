using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace skterminal_fuel_skids_api.Configurations.CustomHttpResponses
{
  public class ExceptionsMiddleware
  {
    private readonly RequestDelegate _next;

    public ExceptionsMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch (Exception ex)
      {
        await HandleExceptionAsync(context, ex);
      }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
      var statusCode = StatusCodes.Status500InternalServerError;

      var errorDetails = new ErrorMessage
      {
        Success = false,
        StatusCode = StatusCodes.Status500InternalServerError,
        Message = ex.Message
      };

      switch (ex)
      {
        case NoContentException noContentException:
          statusCode = StatusCodes.Status204NoContent;
          errorDetails.Success = true;
          errorDetails.StatusCode = StatusCodes.Status204NoContent;
          errorDetails.Message = ex.Message;
          break;
        case NotFoundException notFoundException:
          statusCode = StatusCodes.Status404NotFound;
          errorDetails.Success = true;
          errorDetails.StatusCode = StatusCodes.Status404NotFound;
          errorDetails.Message = ex.Message;
          break;
        case UnauthorizedException unauthorizedException:
          statusCode = StatusCodes.Status401Unauthorized;
          errorDetails.Success = false;
          errorDetails.StatusCode = StatusCodes.Status401Unauthorized;
          errorDetails.Message = ex.Message;
          break;
        case BadRequestException badRequestException:
          statusCode = StatusCodes.Status400BadRequest;
          errorDetails.Success = false;
          errorDetails.StatusCode = StatusCodes.Status400BadRequest;
          errorDetails.Message = ex.Message;
          break;
        case ValidationException validationException:
          statusCode = StatusCodes.Status400BadRequest;
          errorDetails.Message = validationException.Message;
          break;
          // case CantDeleteException cantDeleteException:
          //   statusCode = HttpStatusCode.BadRequest;
          //   errorDetails.ErrorType = "Bad Request";
          //   break;
          // case KeyValueDuplicateException keyValueDuplicateException:
          //   statusCode = HttpStatusCode.Conflict;
          //   errorDetails.ErrorType = "Key Value Duplicate";
          //   break;
          // default:
          //   break;
      }

      var response = JsonConvert.SerializeObject(errorDetails);
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = statusCode;

      return context.Response.WriteAsync(response);
    }
  }

  public class ErrorMessage
  {
    public bool Success { get; set; }
    public int? StatusCode { get; set; }
    public string? Message { get; set; }
  }
}
