var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// MIddlewares is a component that is used in application pipeline to handle requests and responses
// They are chained one after another and execute in the same sequence.


// Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello");
    await next(context);
});

// Middleware 2
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello Again");
    await next(context);
});

// // Middleware 3 (terminal middleware)
// .Run method does not allows us to join to another middleware (cannot form a middlware chain using it)
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello last");
});

app.Run();