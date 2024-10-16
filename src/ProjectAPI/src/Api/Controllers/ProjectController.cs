using Microsoft.AspNetCore.Authorization;
using ProjectAPI.Api.Application.Projects.CreateProject;
using ProjectAPI.Api.Application.Projects.DeleteProject;
using ProjectAPI.Api.Application.Projects.GetAllProjects;
using ProjectAPI.Api.Application.Projects.GetProjectById;
using ProjectAPI.Api.Application.Projects.UpdateProject;
using ProjectAPI.Api.Application.Units.CreateProjectUnit;
using ProjectAPI.Api.Extensions;

namespace ProjectAPI.Api.Controllers;

/// <summary>
/// Controller for managing projects.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class ProjectController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator to handle commands and queries.</param>        

    public ProjectController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Creates a new project.
    /// </summary>
    /// <param name="command">The command containing the details for the new project.</param>
    /// <returns>The response containing the unique identifier of the created project.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [CustomAuthorize("Agent, Admin")]
    public async Task<IActionResult> CreateProject([FromBody] CreateProjectCommand command)
    {

        var rolesClaim = User.FindFirst("Roles")?.Value;
        if (rolesClaim != null)
        {
            var roles = rolesClaim.Split(',').Select(r => r.Trim());
            if (!roles.Contains("Admin") && !roles.Contains("Agent"))
            {
                return Forbid();
            }
        }
        else
        {
            return Forbid();
        }

        var projectId = await _mediator.Send(command);
        var response = new CreateProjectResponse
        {
            ProjectId = projectId,
            Message = "Project created successfully."
        };

        return Ok(response);
    }

    /// <summary>
    /// Gets all projects with optional filters and pagination.
    /// </summary>
    /// <param name="query">The query containing filter and pagination parameters.</param>
    /// <returns>The response containing a paginated list of projects.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllProjects([FromQuery] GetAllProjectsQuery query)
    {
        try
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    /// <summary>
    /// Gets a project by its ID.
    /// </summary>
    /// <param name="id">The ID of the project to retrieve.</param>
    /// <returns>The project details.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProjectById(Guid id)
    {            
        var query = new GetProjectByIdQuery(id);
        var response = await _mediator.Send(query);
        return Ok(response);
    }
    /// <summary>
    /// Updates a project by its ID.
    /// </summary>
    /// <param name="id">The ID of the project to update.</param>
    /// <param name="command">The project update details.</param>
    /// <returns>The updated project details.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [CustomAuthorize("Admin, Agent")]
    public async Task<IActionResult> UpdateProject(Guid id, [FromBody] UpdateProjectCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("Project ID in the URL does not match the command ID.");
        }

        var response = await _mediator.Send(command);
        return Ok(response);
    }


    /// <summary>
    /// Deletes a project by its ID.
    /// </summary>
    /// <param name="id">The ID of the project to delete.</param>
    /// <returns>A response indicating the result of the delete operation.</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [CustomAuthorize("Admin")]
    public async Task<IActionResult> DeleteProject(Guid id)
    {
        var command = new DeleteProjectCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Adds a list of units to a project.
    /// </summary>
    /// <param name="projectId">The ID of the project to which units will be added.</param>
    /// <param name="command">The command containing the list of units to be added.</param>
    /// <returns>A response indicating the result of the add operation.</returns>
    [HttpPost("{projectId}/units")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [CustomAuthorize("Agent")]
    public async Task<IActionResult> AddUnitsToProject(Guid projectId, [FromBody] CreateProjectUnitCommand command)
    {
        command.ProjectId = projectId;
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}
