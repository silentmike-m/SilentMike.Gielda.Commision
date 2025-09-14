using Serilog;
using SilentMike.Gielda.Commision.Application;
using SilentMike.Gielda.Commision.Application.Common.Shared;
using SilentMike.Gielda.Commision.Infrastructure;
using SilentMike.Gielda.Commision.WebApi.Controllers;
using SilentMike.Gielda.Commision.WebApi.Handlers;

const int EXIT_FAILURE = 1;
const int EXIT_SUCCESS = 0;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

builder.Host.UseSerilog((_, lc) => lc
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.WithProperty(nameof(ServiceConstants.ServiceName), ServiceConstants.ServiceName)
    .Enrich.WithProperty(nameof(ServiceConstants.ServiceVersion), ServiceConstants.ServiceVersion));

builder.Services
    .AddProblemDetails(options =>
        options.CustomizeProblemDetails = ctx =>
        {
            ctx.ProblemDetails.Extensions.Add("trace_id", ctx.HttpContext.TraceIdentifier);
            ctx.ProblemDetails.Extensions.Add("request", $"{ctx.HttpContext.Request.Method} {ctx.HttpContext.Request.Path}");
            ctx.ProblemDetails.Extensions.Add("service_name", ServiceConstants.ServiceName);
            ctx.ProblemDetails.Extensions.Add("service_version", ServiceConstants.ServiceVersion);
        });

builder.Services.AddExceptionHandler<ExceptionsHandler>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.FullName);
});

builder.Services.AddSwaggerGen();

builder.Services
    .AddApplication()
    .AddInfrastructure();

try
{
    Log.Information("Starting host...");

    var app = builder.Build();

    app.UseExceptionHandler();

    if (app.Environment.IsProduction() is false)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapCustomers();

    await app.RunAsync();

    return EXIT_SUCCESS;
}
catch (Exception exception)
{
    Log.Fatal(exception, "Host terminated unexpectedly");

    return EXIT_FAILURE;
}
finally
{
    await Log.CloseAndFlushAsync();
}
