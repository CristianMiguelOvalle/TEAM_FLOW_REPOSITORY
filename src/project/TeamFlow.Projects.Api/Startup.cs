using TeamFlow.Projects.Handlers;
using TeamFlow.Projects.Handlers.ProjectHandlers;
using TeamFlow.Projects.Repositories;
using TeamFlow.Projects.Repositories.ProjectRepositories;

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
