using Microsoft.AspNetCore.Authorization;
using ProjectAPI.Api.Application.NotaryAppointments.CreateNotaryAppointment;
using ProjectAPI.Api.Application.NotaryAppointments.GetNotaryAppointmentById;
using ProjectAPI.Api.Application.NotaryAppointments.GetNotaryAppointments;

namespace ProjectAPI.Api.Controllers;

/// <summary>
/// Controller for managing notary appointments.
/// </summary>
[ApiController]
[Route("api/[controller]")]
//[Authorize(Roles = "Admin,Notaire")]
[AllowAnonymous]
public class NotaryAppointmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="NotaryAppointmentsController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator instance.</param>
    public NotaryAppointmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Creates a new notary appointment.
    /// </summary>
    /// <param name="command">The command containing appointment details.</param>
    /// <returns>The response containing the created appointment ID.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateNotaryAppointment([FromBody] CreateNotaryAppointmentCommand command)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetNotaryAppointmentById), new { id = response.Id }, response);
    }

    /// <summary>
    /// Retrieves a notary appointment by ID.
    /// </summary>
    /// <param name="id">The ID of the notary appointment.</param>
    /// <returns>The appointment details.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetNotaryAppointmentById(Guid id)
    {
        var query = new GetNotaryAppointmentByIdQuery { Id = id };
        var response = await _mediator.Send(query);

        if (response == null)
        {
            return NotFound($"Notary appointment with ID {id} not found.");
        }

        return Ok(response);
    }

    /// <summary>
    /// Retrieves a list of notary appointments based on filters.
    /// </summary>
    /// <param name="query">The query containing filters.</param>
    /// <returns>A paginated list of notary appointments.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetNotaryAppointments([FromQuery] GetNotaryAppointmentsQuery query)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _mediator.Send(query);
        return Ok(response);
    }
}
