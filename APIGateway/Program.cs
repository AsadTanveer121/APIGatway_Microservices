using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("configuration.json", optional: false , reloadOnChange:true);

builder.Services.AddOcelot();
var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.UseOcelot().Wait();
app.Run();
