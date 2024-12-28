using ProjectAPI.Api.Application.Projects.CreateProjects;
using ProjectAPI.Api.Application.Projects.GetAllProjects;
using ProjectAPI.Api.Application.Projects.LikedProjects.AddLikedProject;
using ProjectAPI.Api.Application.Projects.LikedProjects.GetLikedProjects;
using ProjectAPI.Api.Application.Projects.LikedProjects.UpdateLikedProject;

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

        [HttpPost("Like")]
        public async Task<IActionResult> AddLikedProject([FromBody] AddLikedProjectCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("LikedProjects")]
        public async Task<IActionResult> GetLikedProjects([FromQuery] GetLikedProjectsQuery query )
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPut("LikedProject")]
        public async Task<IActionResult> UpdateLikedProject([FromBody] UpdateLikedProjectCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}