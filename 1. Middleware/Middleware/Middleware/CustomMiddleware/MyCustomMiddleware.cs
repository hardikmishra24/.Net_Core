using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware.CustomMiddleware
{
    // Custom Middleware class is used to separate the middleware logic from labda expression to seperate class.
    // Middleware class implements an interface called IMIddleware to register itself as a middleware.
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);
        }
    }
}
