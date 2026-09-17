using TeamFlow.Migrator;
using TeamFlow.Projects.Handlers;
using TeamFlow.Projects.Repositories;

namespace TeamFlow.Projects.Api
{
    public class Startup
    {
        public static void ConfigureServices(
        IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddControllers();
            services.AddOpenApi();
            services.AddSwaggerGen();
            services.AddHandler();
            services.AddRepository();
            services.AddTeamFlowContext(configuration);

        }

        public static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
