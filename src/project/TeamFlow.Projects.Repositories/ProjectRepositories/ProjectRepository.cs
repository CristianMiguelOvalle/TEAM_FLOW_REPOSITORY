using Microsoft.EntityFrameworkCore;
using TeamFlow.Common.Dto.Project;
using TeamFlow.Common.ViewModels;
using TeamFlow.DB;

namespace TeamFlow.Projects.Repositories.ProjectRepositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TeamFlowContext _teamFlowContext;

        public ProjectRepository(TeamFlowContext teamFlowContext)
        {
            _teamFlowContext = teamFlowContext;
        }

        public async Task<PaginationResult<ProjectDto>> GetProjectList(PaginationRequest<ProjectDto_FilterRequest> request)
        {
            IQueryable<ProjectDto> query = (IQueryable<ProjectDto>)_teamFlowContext.Projects;

            if (request.Params.Name !=  null)
            {
                query = query.Where(p => p.Name.Contains(request.Params.Name));
            }

            if (request.Params.Description != null)
            {
                query = query.Where(p => p.Description.Contains(request.Params.Description));
            }

            query.Select(p => new ProjectDto
             {
                 Id = p.Id.ToString(),
                 Name = p.Name,
                 Description = p.Description,
                 Status = p.Status,
             });

            return await PaginationResultExtension<ProjectDto>.SetGridPaginationResult(query,request.Page, request.PageSize);
        }

        public async Task<ProjectDto?> GetProjectById(Guid id)
        {
            ProjectDto? result = await _teamFlowContext
                .Projects
                .Where(p => p.Id == id)
                .Select(p => new ProjectDto
                    {
                      Id = p.Id.ToString(),
                      Description = p.Description,
                      Name = p.Name,
                      Status = p.Status,
                    })
                .FirstOrDefaultAsync();

            return result;
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
