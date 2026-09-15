using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.Common.Dto.Project;
using TeamFlow.Common.ViewModels;
using TeamFlow.DB.entities;
using TeamFlow.DB.enums;

namespace TeamFlow.Projects.Repositories.ProjectRepositories
{
    public class ProjectRepository : IProjectRepository
    {
        public async Task<PaginationResult<ProjectDto>> GetProjectList(PaginationRequest<ProjectDto_FilterRequest> request)
        {
            return new PaginationResult<ProjectDto>();
        }

        public Task<ProjectDto> GetProjectById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDto> CreateProject(ProjectDto_CreateRequest project)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDto> UpdateProject(ProjectDto_UpdateRequest project, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDto> DeleteProject(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
