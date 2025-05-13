using ChronoQuest.Core.Domain;
using ChronoQuest.Core.Infrastructure;
using ChronoQuest.Endpoints;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting ChronoQuest web API...");
    var builder = WebApplication.CreateBuilder(args);

    builder.Services
        .AddSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration))
        .AddAuthorization()
        .AddCors()
        .AddInfrastructure(builder.Configuration)
        .AddOpenApi()
        .AddChronoQuestEndpoints();

    var app = builder.Build();
    
    app.UseSerilogRequestLogging();
    app.MapOpenApi();
    app.MapIdentityApi<User>();
    app.MapChronoQuestEndpoints();
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    app.Run();
}
catch (Exception e)
{
    Log.Fatal(e, "ChronoQuest has terminated due to an error (or an EF Core migration/update).");
}
finally
{
    Log.CloseAndFlush();
}