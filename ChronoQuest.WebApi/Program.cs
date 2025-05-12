using ChronoQuest.Core.Infrastructure;
using ChronoQuest.Endpoints;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting ChronoQuest web API...");
    var builder = WebApplication.CreateBuilder(args);

    builder.Services
        .AddSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration))
        .AddInfrastructure(builder.Configuration)
        .AddOpenApi()
        .AddChronoQuestEndpoints();

    var app = builder.Build();

    app.UseSerilogRequestLogging();
    app.MapOpenApi();
    app.MapChronoQuestEndpoints();

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