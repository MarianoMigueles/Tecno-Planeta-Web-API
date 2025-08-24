using Azure;
using Exeptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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
            catch (AbstractBaseExeption ex)
            {
                _logger.LogError($"Bad request: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, AbstractBaseExeption ex)
        {
            ProblemDetails problem;
            int status = GetStatusCode(ex);
            problem = CreateProblemDetail(ex, status, context);

            context.Response.ContentType = "application/problem+json";
            return context.Response.WriteAsJsonAsync(problem);
        }

        private static int GetStatusCode(AbstractBaseExeption ex)
        {
            /*
             * the list of exceptions that are from status 500 error code.
                - DatabaseOperationException
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

        private static ProblemDetails CreateProblemDetail(AbstractBaseExeption ex, int statusCode, HttpContext context)
        {
            var problem = new ProblemDetails
            {
                Type = ex.Type,
                Title = ex.Title,
                Status = statusCode,
                Detail = ex.Message,
                Instance = context.Request.Path
            };

            return problem;
        }
    }
}
