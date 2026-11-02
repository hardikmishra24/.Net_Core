namespace Middleware.CustomMiddleware
{
    // Custom Middleware class is used to separate the middleware logic from labda expression to seperate class.
    // Middleware class implements an interface called IMIddleware to register itself as a middleware.
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My Custon Middleware - started ");
            await next(context);
            await context.Response.WriteAsync("Custom Middleware - ended ");
         }
    }

    //Creating the extension method
    public static class CustomMiddlewareExtension 
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app) // We can access this function using the app object.
        {
            return app.UseMiddleware<MyCustomMiddleware>();
        } 
    }
}


