using Microsoft.AspNetCore.Authorization;
using ProjectAPI.Api.Application.Feedbacks.SubmitFeedback;

namespace ProjectAPI.Api.Controllers;

/// <summary>
/// Controller for handling feedback submissions on projects or the application.
/// </summary>
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
    [Authorize(Roles = "Acheteur")]
    public async Task<IActionResult> SubmitFeedback([FromBody] SubmitFeedbackCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
