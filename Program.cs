
using Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
//Commenting Short circuiting/terminating middleware
//app.Run(async (Context) => {
//    await Context.Response.WriteAsync("This is short circuit Middleware");
//});

app.Use(async (Context, next) =>
{
    await Context.Response.WriteAsync("<p>This is responsibility of Middleware 1</p>");
    await next(Context);
    Context.Response.ContentType = "text/html";
});

//app.Use(async (Context, next) => {
//    await Context.Response.WriteAsync("<p>This is responsibility of Middleware 2</p>");
//    await next(Context);
//});
app.UseMiddleware<MyCustomMiddleware>();

app.Run(async (Context) => {
    await Context.Response.WriteAsync("<p>This is responsibility of Middleware 3</p>");

});

app.Run();
