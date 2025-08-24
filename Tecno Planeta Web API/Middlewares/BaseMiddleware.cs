namespace Tecno_Planeta_Web_API.Middlewares
{
    public class BaseMiddleware(RequestDelegate next, ILogger<BaseMiddleware> logger)
    {
        protected readonly RequestDelegate _next;
        protected readonly ILogger<BaseMiddleware> _logger;
    }
}
