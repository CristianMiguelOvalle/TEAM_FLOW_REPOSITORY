using Microsoft.AspNetCore.Mvc;
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

        [HttpGet()]
        public async Task<ActionResult> GetProjects()
        {
            return Ok(_projectHandler.GetProjectList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>>GetById(string id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Project>>Create(Project project)
        {
            return Ok(new Project());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> Update(Project project, string id)
        {
            return Ok(new Project());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            return Ok(true);
        }
    }
}
