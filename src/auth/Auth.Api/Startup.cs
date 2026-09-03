using TeamFlow.Common.middleware;

namespace Auth.Api
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
        }

        public static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<RequestLoggingMiddleware>();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
