using Microsoft.AspNetCore.Authorization;
using ProjectAPI.Api.Application.Feedbacks.GetFeedbackById;
using ProjectAPI.Api.Application.Feedbacks.GetFeedbackByProjectId;
using ProjectAPI.Api.Application.Feedbacks.GetFeedBackByUserId;
using ProjectAPI.Api.Application.Feedbacks.SubmitFeedback;
using ProjectAPI.Api.Extensions;
using System.Security.Claims;

namespace ProjectAPI.Api.Controllers;

/// <summary>
/// Controller for handling feedback submissions on projects or the application.
/// </summary>    

[Authorize(AuthenticationSchemes = "Bearer")]
[ApiController]
[Route("api/[controller]")]
public class FeedbackController : ControllerBase
{
    private readonly IMediator _mediator;

    public FeedbackController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Submits feedback for a specific project or the application.
    /// </summary>
    /// <param name="command">The feedback command containing user ID, project ID, rating, and comments.</param>
    /// <returns>A response indicating the result of the feedback submission.</returns>
    [HttpPost("submit-feedback")]
    [CustomAuthorize("Acheteur")]
    public async Task<IActionResult> SubmitFeedback([FromBody] SubmitFeedbackCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    /// <summary>
    /// Gets feedback by its ID.
    /// </summary>
    /// <param name="feedbackId">The ID of the feedback to retrieve.</param>
    /// <returns>A response containing feedback details, including user and project information.</returns>
    [HttpGet("{feedbackId}")]
    [Authorize(Roles = "Admin, Agent")]

    public async Task<IActionResult> GetFeedbackById(Guid feedbackId)
    {
        var rolesClaim = User.FindFirst("Roles")?.Value ?? User.FindFirst(ClaimTypes.Role)?.Value;
        if (rolesClaim != null)
        {
            var roles = rolesClaim.Split(',').Select(r => r.Trim());
            if (!roles.Contains("Admin") && !roles.Contains("Agent") && !roles.Contains("Acheteur"))
            {
                return Forbid();
            }
        }
        else
        {
            return Forbid();
        }
        var query = new GetFeedbackByIdQuery { FeedbackId = feedbackId };
        var feedback = await _mediator.Send(query);
        return Ok(feedback);
    }

    /// <summary>
    /// Gets feedback by the project ID.
    /// </summary>
    /// <param name="projectId">The ID of the project for which feedback is to be retrieved.</param>
    /// <returns>A response containing a list of feedbacks for the given project.</returns>
    [HttpGet("by-project/{projectId}")]
    [Authorize(Roles = "Acheteur,Admin,Agent")]
    public async Task<IActionResult> GetFeedbackByProjectId(Guid projectId)
    {
        var query = new GetFeedbackByProjectIdQuery { ProjectId = projectId };
        var feedbackList = await _mediator.Send(query);
        return Ok(feedbackList);
    }

    /// <summary>
    /// Gets feedback by the user ID.
    /// </summary>
    /// <param name="userId">The ID of the user for which feedback is to be retrieved.</param>
    /// <returns>A response containing a list of feedbacks submitted by the given user.</returns>
    [HttpGet("by-user/{userId}")]
    [Authorize(Roles = "Acheteur,Admin,Agent")]
    public async Task<IActionResult> GetFeedbackByUserId(string userId)
    {
        var query = new GetFeedbackByUserIdQuery { UserId = Guid.Parse(userId) };
        var feedbackList = await _mediator.Send(query);
        return Ok(feedbackList);
    }
}
