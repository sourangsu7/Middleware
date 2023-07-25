namespace Middleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("<p>Middleware 2 implementation starts here ...</p>");
            await context.Response.WriteAsync("<p>This implementation is responsibility of Middleware 2 ...</p>");
            await next(context);
            await context.Response.WriteAsync("<p>Middleware 2 implementation ends here ...</p>");
        }
    }
}
