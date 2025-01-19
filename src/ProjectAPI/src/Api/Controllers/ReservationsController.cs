using ProjectAPI.Api.Application.Reservations.CreateReservation;
using ProjectAPI.Api.Application.Reservations.GetReservationById;
using ProjectAPI.Api.Application.Reservations.GetReservations;

namespace ProjectAPI.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReservationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateReservation([FromBody] CreateReservationCommand command)
    {
        var response = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetReservationById), new { id = response.ReservationId }, response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetReservationById(Guid id)
    {
        var response = await _mediator.Send(new GetReservationByIdQuery { ReservationId = id });
        return Ok(response);
    }

    [HttpGet("list")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetReservations([FromQuery] GetReservationsQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }
}
