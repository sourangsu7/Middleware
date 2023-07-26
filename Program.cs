
using Middleware;
using MiddleWareExamples.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
builder.Services.AddTransient<MiddlewareExtensionImplement>();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
//Commenting Short circuiting/terminating middleware
//app.Run(async (Context) => {
//    await Context.Response.WriteAsync("This is short circuit Middleware");
//});
app.UseTimeLogger();
app.Use(async (Context, next) =>
{
    //Context.Response.ContentType = "text/html";
    await Context.Response.WriteAsync("<p>This is responsibility of Middleware 1</p>");
    await next(Context);
});

//app.Use(async (Context, next) => {
//    await Context.Response.WriteAsync("<p>This is responsibility of Middleware 2</p>");
//    await next(Context);
//});
app.UseMiddleware<MyCustomMiddleware>();

app.UseMyCustomMiddleware();
app.UseGreetingMiddleware();

app.Run(async (Context) => {
    await Context.Response.WriteAsync("<p>This is responsibility of Middleware 3</p>");

});

app.Run();
