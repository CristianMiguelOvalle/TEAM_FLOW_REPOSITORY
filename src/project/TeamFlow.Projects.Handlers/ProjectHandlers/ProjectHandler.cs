using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.DB.entities;
using TeamFlow.Projects.Repositories.ProjectRepositories;

namespace TeamFlow.Projects.Handlers.ProjectHandlers
{
    public class ProjectHandler : IProjectHandler
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public List<Project> GetProjectList()
        {
            return _projectRepository.GetProjectList();
        }
    }
}
