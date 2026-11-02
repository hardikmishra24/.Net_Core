using Middleware.CustomMiddleware;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

// MIddlewares is a component that is used in application pipeline to handle requests and responses
// They are chained one after another and execute in the same sequence.


// Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello ");
    await next(context);    // Written for connecting the middleware to the next middleware and in the paramters the httpcontext object reference is passed.
});

// Middleware 2  [UseMiddleware function is used to Connect to custom middleware class.] 
//app.UseMiddleware<MyCustomMiddleware>();


// Connecting the middleware using the extension method (it is not necessary but a common convention)
app.UseCustomMiddleware();





// // Middleware 3 (terminal middleware)
// .Run method does not allows us to join to another middleware (cannot form a middlware chain using it)
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello last ");
});

app.Run();





