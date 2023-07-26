using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddleWareExamples.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TimeLogger
    {
        private readonly RequestDelegate _next;

        public TimeLogger(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync($"<p>Inbound Request comes at @{DateTimeOffset.UtcNow}</p>");
            await _next(httpContext);
            await httpContext.Response.WriteAsync($"<p>Outbound Request goes at @{DateTimeOffset.UtcNow}</p>");

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseTimeLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeLogger>();
        }
    }
}
