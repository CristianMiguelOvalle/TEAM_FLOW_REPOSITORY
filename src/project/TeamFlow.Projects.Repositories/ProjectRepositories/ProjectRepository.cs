using Microsoft.EntityFrameworkCore;
using TeamFlow.Common.Dto.Project;
using TeamFlow.Common.Dto.ProjectTask;
using TeamFlow.Common.ViewModels;
using TeamFlow.DB;
using TeamFlow.DB.entities;

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
            IQueryable<Project> query = _teamFlowContext.Projects;

            if (request.Params.Name !=  null)
            {
                query = query.Where(p => p.Name.Contains(request.Params.Name));
            }

            if (request.Params.Description != null)
            {
                query = query.Where(p => p.Description.Contains(request.Params.Description));
            }

            query = query
                    .OrderByDescending(p => p.CreatedDate)
                    .ThenBy(p => p.Id);

            IQueryable<ProjectDto> projectedQuery =
                    query.Select(p => new ProjectDto
                    {
                        Id = p.Id.ToString(),
                        Name = p.Name,
                        Description = p.Description,
                        Status = p.Status
                    });

            return await PaginationResultExtension<ProjectDto>.SetGridPaginationResult(projectedQuery, request.Page, request.PageSize);
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

        public async Task<ProjectDto> CreateProject(ProjectDto_CreateRequest project, CancellationToken cancellationToken)
        {

            var entity = new Project()
            {
                Description = project.Description,
                Name = project.Name,
                IsActive = true,
                Status = DB.enums.ProjectStatusEnum.Created,
                OwnerId = project.OwnerId,
            };

            _teamFlowContext.Projects.Add(entity);
            await _teamFlowContext.SaveChangesAsync(cancellationToken);

            return new ProjectDto()
            {
                Description = entity.Description,
                Id = entity.Id.ToString(),
                Name = entity.Name,
                Status = entity.Status,
            };
        }   

        public async Task<ProjectDto> UpdateProject(ProjectDto_UpdateRequest project, Guid id, CancellationToken cancellationToken)
        {
            var entity = await _teamFlowContext.Projects.FirstOrDefaultAsync(p => p.Id == id);

            if (entity == null)
            {
                throw new Exception("No existe un proyecto con este id");
            }

            entity.Name = project.Name;
            entity.Description = project.Description;
            entity.IsActive = project.IsActive;
            entity.Status = project.Status;
            entity.OwnerId = project.OwnerId;

            await _teamFlowContext.SaveChangesAsync(cancellationToken);

            return new ProjectDto()
            {
                Description = entity.Description,
                Id = entity.Id.ToString(),
                Name = entity.Name,
                Status = entity.Status,
            };
        }

        public async Task<bool> DeleteProject(Guid id)
        {
            var entity = await _teamFlowContext.Projects.FirstOrDefaultAsync(p => p.Id == id);

            if (entity == null)
            {
                throw new Exception("No existe un proyecto con este id");
            }

            entity.IsDelete = true;
            await _teamFlowContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProjectTaskDto>>GetProjectTasks(Guid projectId)
        {
            var taskList = await _teamFlowContext.ProjectTasks
                .Where(pt => pt.ProjectId == projectId)
                .Select(t => new ProjectTaskDto
                {
                    Id = t.Id,
                    Description = t.Description,
                    Priority = t.Priority,
                    Status = t.Status,
                    IsActive = t.IsActive,
                    AssignedUserId = t.AssignedUserId,
                    Title = t.Title,
                })
                .ToListAsync();

            return taskList;
        }
    }
}
