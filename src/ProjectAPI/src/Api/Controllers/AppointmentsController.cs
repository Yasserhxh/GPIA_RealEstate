﻿using Microsoft.AspNetCore.Authorization;
using ProjectAPI.Api.Application.Appointments.CreateAppointment;

namespace ProjectAPI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class AppointmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppointmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Creates a new appointment.
    /// </summary>
    /// <param name="command">The appointment creation command.</param>
    /// <returns>A response containing the appointment ID and a success message.</returns>
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentCommand command)
    {
        var userId = User.FindFirst("UserId")?.Value;
        var rolesClaim = User.FindFirst("Roles")?.Value;
        var roles = rolesClaim?.Split(',').Select(r => r.Trim());

        if (roles != null && roles.Contains("Agent"))
        {
            // If the user is an agent, use the UserId from claims as the AgentId
            command.AgentId = Guid.Parse(userId);

        }
        else if (roles != null && (roles.Contains("Acheteur") || roles.Contains("Visiteur") || roles.Contains("Other")))
        {
            // If the user is an authenticated visitor or buyer
            command.UserId = userId;
        }
        else if (string.IsNullOrEmpty(userId))
        {
            // If the user is not authenticated, agentId must be provided in the request body
            if (command.AgentId == Guid.Empty)
            {
                return BadRequest("AgentId is required for unauthenticated users.");
            }
        }

        var response = await _mediator.Send(command);
        return Ok(response);
    }
/*
    /// <summary>
    /// Gets all appointments for a specific user by their user ID.
    /// </summary>
    /// <param name="userId">The user ID to retrieve appointments for.</param>
    /// <returns>A list of appointments associated with the user.</returns>
    [HttpGet("user/{userId}")]
    [Authorize(Roles = "Acheteur,Admin,Agent")]
    public async Task<IActionResult> GetAppointmentsByUserId(string userId)
    {
        var query = new GetAppointmentsByUserIdQuery { UserId = userId };
        var appointments = await _mediator.Send(query);
        return Ok(appointments);
    }

    /// <summary>
    /// Gets all appointments for a specific project by project ID.
    /// </summary>
    /// <param name="projectId">The project ID to retrieve appointments for.</param>
    /// <returns>A list of appointments associated with the project.</returns>
    [HttpGet("project/{projectId}")]
    [Authorize(Roles = "Acheteur,Admin,Agent")]
    public async Task<IActionResult> GetAppointmentsByProjectId(Guid projectId)
    {
        var query = new GetAppointmentsByProjectIdQuery { ProjectId = projectId };
        var appointments = await _mediator.Send(query);
        return Ok(appointments);
    }
*/
}