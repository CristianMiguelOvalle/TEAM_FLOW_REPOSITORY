using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeamFlow.DB;

namespace TeamFlow.Migrator
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTeamFlowContext(
       this IServiceCollection services,
       IConfiguration configuration)
        {
            var connectionString =
                configuration.GetConnectionString("TeamFlowConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "No se encontró la conexión 'TeamFlowConnection' en la configuración.");
            }

            services.AddDbContext<TeamFlowContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
    }
}
