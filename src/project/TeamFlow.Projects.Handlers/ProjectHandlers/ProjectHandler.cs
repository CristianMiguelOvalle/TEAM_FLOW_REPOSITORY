using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.Common.Dto.Project;
using TeamFlow.Common.Dto.ProjectTask;
using TeamFlow.Common.ViewModels;
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

        public async Task<PaginationResult<ProjectDto>> GetProjectList(PaginationRequest<ProjectDto_FilterRequest> request)
        {
            return await _projectRepository.GetProjectList(request);
        }

        public async Task<ProjectDto?> GetProjectById(Guid id)
        {
            return await _projectRepository.GetProjectById(id);
        }

        public async Task<ProjectDto> CreateProject(ProjectDto_CreateRequest project, CancellationToken cancellationToken)
        {
            return await _projectRepository.CreateProject(project, cancellationToken);
        }

        public async Task<ProjectDto> UpdateProject(ProjectDto_UpdateRequest project, Guid id, CancellationToken cancellationToken)
        {
            return await _projectRepository.UpdateProject(project, id, cancellationToken);
        }

        public async Task<bool> DeleteProject(Guid id)
        {
            return await _projectRepository.DeleteProject(id);
        }

        public async Task<List<ProjectTaskDto>>GetProjectTasks(Guid projectId)
        {
            return await _projectRepository.GetProjectTasks(projectId);
        }
    }
}
