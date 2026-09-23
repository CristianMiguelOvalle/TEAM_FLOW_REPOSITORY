using Microsoft.AspNetCore.Mvc;
using TeamFlow.Common.Dto.Project;
using TeamFlow.Common.Dto.ProjectTask;
using TeamFlow.Common.ViewModels;
using TeamFlow.DB.entities;
using TeamFlow.Projects.Handlers.ProjectHandlers;

namespace TeamFlow.Projects.Api.Controllers
{
    [Route("api/v1/[Controller]")]   
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectHandler _projectHandler;

        public ProjectsController(IProjectHandler projectHandler)
        {
            _projectHandler = projectHandler;
        }

        [HttpGet("list")]
        public async Task<ActionResult<PaginationResult<ProjectDto>>> GetProjects(PaginationRequest<ProjectDto_FilterRequest> request)
        {
            return Ok(await _projectHandler.GetProjectList(request));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto?>>GetProjectById(Guid id)
        {
            return Ok(await _projectHandler.GetProjectById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>>CreateProject(ProjectDto_CreateRequest project, CancellationToken cancellationToken = default)
        {
            return Ok(await _projectHandler.CreateProject(project, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProjectDto>> Update(ProjectDto_UpdateRequest project, Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(await _projectHandler.UpdateProject(project, id, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return Ok(await _projectHandler.DeleteProject(id));
        }

        [HttpGet("{projectId}/tasks")]
        public async Task<ActionResult<List<ProjectTaskDto>>> GetProjectTasks(Guid projectId)
        {
            return Ok(await _projectHandler.GetProjectTasks(projectId));
        }
    }
}
