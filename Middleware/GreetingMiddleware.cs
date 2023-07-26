using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddleWareExamples.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GreetingMiddleware
    {
        private readonly RequestDelegate _next;

        public GreetingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if(httpContext.Request.Query.ContainsKey("firstname") 
                && httpContext.Request.Query.ContainsKey("lastname"))
            {
                var fullName = $"Greeting to ASP.NET Core {httpContext.Request.Query["firstname"]} {httpContext.Request.Query["lastname"]}";

                await httpContext.Response.WriteAsync(fullName);
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GreetingMiddlewareExtensions
    {
        public static IApplicationBuilder UseGreetingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GreetingMiddleware>();
        }
    }
}
