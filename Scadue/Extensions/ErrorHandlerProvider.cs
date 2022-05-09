using Microsoft.AspNetCore.Builder;
using Scadue.Middleware;

namespace Scadue.Extensions
{
    public static class ErrorHandlerProvider
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandler>();
        }
    }
}
