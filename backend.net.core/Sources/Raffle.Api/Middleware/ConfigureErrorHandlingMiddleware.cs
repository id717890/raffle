using Microsoft.AspNetCore.Builder;

namespace Raffle.Api.Middleware
{
    public static class ConfigureErrorHandlingMiddleware
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
