namespace MiddleWareExamples.Middleware
{
    public class MiddlewareExtensionImplement : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("<p>Custom layer kicks in</p>");
            await context.Response.WriteAsync("<p>Custom layer implementation happens here!</p>");
            await next(context);
            await context.Response.WriteAsync("<p>Custom layer implementation responsibility ends here!</p>");

        }
    }
    public static class MiddlewareRunTask
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<MiddlewareExtensionImplement>();
            return app;
        }
    }
}
