using Microsoft.AspNetCore.Mvc;
using TeamFlow.DB.entities;

namespace TeamFlow.Projects.Api.Controllers
{
    [Route("api/v1/[Controller]")]   
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        public ProjectsController()
        {
        }

        [HttpGet()]
        public async Task<ActionResult> GetProjects()
        {
            return Ok();
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
