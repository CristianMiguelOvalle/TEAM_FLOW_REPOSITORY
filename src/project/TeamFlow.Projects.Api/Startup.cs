using TeamFlow.Projects.Handlers.ProjectHandlers;
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

            #region Repositories
            services.AddScoped<IProjectRepository, ProjectRepository>();
            #endregion

            #region Handlers
            services.AddTransient<IProjectHandler, ProjectHandler>();
            #endregion
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
