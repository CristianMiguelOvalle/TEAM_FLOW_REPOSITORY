using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.Projects.Handlers.ProjectHandlers;

namespace TeamFlow.Projects.Handlers
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddHandler(this IServiceCollection services)
        {
            services.AddTransient<IProjectHandler, ProjectHandler>();
            return services;
        }
    }
}
