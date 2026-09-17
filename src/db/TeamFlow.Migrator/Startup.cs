using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeamFlow.DB;

namespace TeamFlow.Migrator
{
    internal class Startup
    {
       public static void ConfigureServices(
       IServiceCollection services,
       IConfiguration configuration)
        {
            services.AddTeamFlowContext(configuration);
        }

        public static async Task RunAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<TeamFlowContext>();

            await context.Database.MigrateAsync();
        }
    }
}
