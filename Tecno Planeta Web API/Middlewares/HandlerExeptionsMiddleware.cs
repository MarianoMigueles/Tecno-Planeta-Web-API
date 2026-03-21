using Exeptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Tecno_Planeta_Web_API.Middlewares
{
    public class HandlerExeptionsMiddleware(RequestDelegate next, ILogger<HandlerExeptionsMiddleware> logger) : BaseMiddleware(next, logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Bad request: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ProblemDetails problem;
            int status = GetStatusCode(ex);

            if(ex is AbstractBaseExeption absEx)
            {          
                problem = CreateProblemDetail(
                    absEx.Type,
                    absEx.Title,
                    absEx.Message,
                    status,
                    context
                );
            } 
            else
            {
                problem = CreateProblemDetail(
                    "https://example.com/errors/internal-server-error",
                    "Internal server error.",
                    "An unexpected error has occurred. Please try again later.",
                    status,
                    context
                );
            }

            context.Response.ContentType = "application/problem+json";
            return context.Response.WriteAsJsonAsync(problem);
        }

        private static int GetStatusCode(Exception ex)
        {
            /*
               List of exceptions that are from status 500 error code:
                   - DatabaseOperationException
                   - Generic or uncontrolled exceptions
            */
            int status = StatusCodes.Status500InternalServerError;

            switch (ex)
            {
                case EntityAlreadyExistsException:
                    status = StatusCodes.Status409Conflict;
                    break;
                case EntityDeletionException:
                case EntityNotFoundException:
                    status = StatusCodes.Status404NotFound;
                    break;

                case EntityUpdateException:
                case EntityCreationException:
                case InvalidEntityException:
                case InvalidStateException:
                case InvalidateOperationExeption:
                    status = StatusCodes.Status400BadRequest;
                    break;
                case UnauthorizedAccessExeption:
                    status = StatusCodes.Status403Forbidden;
                    break;
            }

            return status;
        }

        private static ProblemDetails CreateProblemDetail(string type, string title, string message, int statusCode, HttpContext context)
        {
            var problem = new ProblemDetails
            {
                Type = type,
                Title = title,
                Status = statusCode,
                Detail = message,
                Instance = context.Request.Path
            };

            return problem;
        }
    }
}
