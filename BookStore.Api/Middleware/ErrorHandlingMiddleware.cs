using System.Net;
using System.Text.Json;

namespace BookStore.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext ctx)
        {
            try
            {
                await _next(ctx);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                ctx.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                ctx.Response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(new { error = "An unexpected error occurred." });
                await ctx.Response.WriteAsync(result);
            }
        }
    }

    public static class ErrorHandlingExtensions
    {
        public static IApplicationBuilder UseCustomErrorHandling(this IApplicationBuilder app)
            => app.UseMiddleware<ErrorHandlingMiddleware>();
    }
}
