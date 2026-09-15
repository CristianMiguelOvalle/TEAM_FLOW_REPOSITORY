using System;
using System.Collections.Generic;
using System.Text;
using TeamFlow.Common.Dto.Project;
using TeamFlow.Common.ViewModels;
using TeamFlow.DB.entities;

namespace TeamFlow.Projects.Handlers.ProjectHandlers
{
    public interface IProjectHandler
    {
        Task<PaginationResult<ProjectDto>> GetProjectList(PaginationRequest<ProjectDto_FilterRequest> request);
        Task<ProjectDto> GetProjectById(Guid id);
        Task<ProjectDto> CreateProject(ProjectDto_CreateRequest project);
        Task<ProjectDto> UpdateProject(ProjectDto_UpdateRequest project, Guid id);
        Task<ProjectDto> DeleteProject(Guid Id);
    }
}
