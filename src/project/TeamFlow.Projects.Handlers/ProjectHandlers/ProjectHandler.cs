using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.Common.Dto.Project;
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

        public async Task<ProjectDto> GetProjectById(Guid id)
        {
            return await _projectRepository.GetProjectById(id);
        }

        public async Task<ProjectDto> CreateProject(ProjectDto_CreateRequest project)
        {
            return await _projectRepository.CreateProject(project);
        }

        public async Task<ProjectDto> UpdateProject(ProjectDto_UpdateRequest project, Guid id)
        {
            return await _projectRepository.UpdateProject(project, id);
        }

        public async Task<ProjectDto> DeleteProject(Guid id)
        {
            return await _projectRepository.DeleteProject(id);
        }
    }
}
