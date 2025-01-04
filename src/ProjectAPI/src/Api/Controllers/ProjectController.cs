using ProjectAPI.Api.Application.Projects.AddProjectFratures;
using ProjectAPI.Api.Application.Projects.CreateProjects;
using ProjectAPI.Api.Application.Projects.GetAllProjects;
using ProjectAPI.Api.Application.Projects.GetProjectFeatures;
using ProjectAPI.Api.Application.Projects.LikedProjects.AddLikedProject;
using ProjectAPI.Api.Application.Projects.LikedProjects.GetLikedProjects;
using ProjectAPI.Api.Application.Projects.LikedProjects.UpdateLikedProject;

namespace ProjectAPI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = "Bearer")]
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
    //[CustomAuthorize("Agent")]
    public async Task<IActionResult> GetAllProjects([FromQuery] GetAllProjectsQuery query)
    {
        /*var idClaims = User.FindFirst("userId")?.Value;
        query.UserId = idClaims;*/
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

    /// <summary>
    /// Add features to a Project.
    /// </summary>
    /// <param name="command">The command containing the features to add.</param>
    /// <returns>Success status.</returns>
    [HttpPost("features")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddProjectFeatures([FromBody] AddProjectFeatureCommand command)
    {
        var result = await _mediator.Send(command);
        return result ? Ok("Features added successfully.") : BadRequest("Failed to add features.");
    }

    /// <summary>
    /// Get all features for a specific Project.
    /// </summary>
    /// <param name="query">The query containing the Project ID.</param>
    /// <returns>List of features.</returns>
    [HttpGet("features")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProjectFeatures([FromQuery] GetProjectFeaturesQuery query)
    {
        var features = await _mediator.Send(query);
        if (features == null || features.Count == 0)
            return NotFound("No features found for the specified Project.");

        return Ok(features);
    }
}