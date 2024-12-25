using ProjectAPI.Api.Application.Projects.CreateProjects;
using ProjectAPI.Api.Application.Projects.GetAllProjects;

namespace ProjectAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects([FromQuery] GetAllProjectsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}