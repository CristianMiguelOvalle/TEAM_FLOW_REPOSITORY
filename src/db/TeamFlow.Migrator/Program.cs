using Microsoft.Extensions.Hosting;
using TeamFlow.Migrator;

var builder = Host.CreateApplicationBuilder(args);

Startup.ConfigureServices(
    builder.Services,
    builder.Configuration);

using var host = builder.Build();

await Startup.RunAsync(host.Services);