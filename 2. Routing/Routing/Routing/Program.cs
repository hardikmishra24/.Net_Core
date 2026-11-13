var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();




app.UseEndpoints(endpoints =>
{

    app.Use(async (context, next) =>
    {
        var endpoint = context.GetEndpoint();
        await context.Response.WriteAsync($"{endpoint?.DisplayName ?? "No endpoint matched\n"}");
        await next(context);
    });



    // filename and extension are dynamic 'route parameters which can change
    endpoints.Map("folder/{name=hardik}", async context =>
    {
       
        string? name = Convert.ToString(context.Request.RouteValues["name"]);
        await context.Response.WriteAsync($" In this the name is {name} ");
    });


    //endpoints.Map("files/{filename}.{extension}", async context =>
    //{
    //    string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
    //    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
    //    await context.Response.WriteAsync($" In this {filename} and {extension} ");
    //});


    endpoints.MapGet("map1", async (context) =>
    {
        await context.Response.WriteAsync(" In map 1");
    });


    endpoints.MapPost("map2", async (context) =>
    {
        await context.Response.WriteAsync(" In map 2");
    });


});


app.Run();


