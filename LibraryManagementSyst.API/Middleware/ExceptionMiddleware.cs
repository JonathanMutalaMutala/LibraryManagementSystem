using LibraryManagementSyst.API.Models;
using LibraryManagementSystem.Application.Exceptions;
using System.Net;

namespace LibraryManagementSyst.API.Middleware
{
    /// <summary>
    /// Ce Middleware permettra des catchs erreurs,les exceptions et envoyés de l'information au Body de la response
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
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

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            CustomProblemDetails customProblemDetails = new CustomProblemDetails();

            switch (ex)
            {
                //Si cette exception correspond à l'instance de la class BadRequestException qu'on a crée il fait custom le Body Responses
                case BadRequestException badRequestException:

                    statusCode = HttpStatusCode.BadRequest; // Envoie de bon status au Responses 

                    customProblemDetails = new CustomProblemDetails
                    {
                        Title = badRequestException.Message,
                        Status = (int)statusCode,
                        Detail = badRequestException.InnerException?.Message,
                        Type = nameof(BadRequestException),
                        CurrentTrace = badRequestException.StackTrace,
                        ErrorsDetailsDictionnary = badRequestException.ValidationErrors
                    };
                    break;
                case NotFoundException NotFound:
                    statusCode = HttpStatusCode.NotFound;
                    customProblemDetails = new CustomProblemDetails
                    {
                        Title = NotFound.Message,
                        Status = (int)statusCode,
                        Detail = NotFound.InnerException?.Message,
                        Type = nameof(BadRequestException),
                        CurrentTrace = NotFound.StackTrace
                    };
                    break;
                default:
                    customProblemDetails = new CustomProblemDetails
                    {
                        Title = ex.Message,
                        Status = (int)statusCode,
                        Detail = ex.StackTrace, // Avoir la Trace de l'element
                        Type = nameof(HttpStatusCode.InternalServerError),
                        
                    };
                    break;
            }

            context.Response.StatusCode = (int) statusCode;

            await context.Response.WriteAsJsonAsync(customProblemDetails);
        }
    }
}
