using ProjectAPI.Domain.Appointments.Entities;
using ProjectAPI.Domain.Appointments.Interfaces;
using ProjectAPI.Api.Application.Common.Exceptions;
using Microsoft.AspNetCore.Identity;
using ProjectAPI.Domain.Users.Entities;

namespace ProjectAPI.Api.Application.Appointments.CreateAppointment;

/// <summary>
/// Handles the creation of a new appointment.
/// </summary>
public class CreateAppointmentHandler : IRequestHandler<CreateAppointmentCommand, CreateAppointmentResponse>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly UserManager<User> _userManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateAppointmentHandler"/> class.
    /// </summary>
    /// <param name="appointmentRepository">The repository for managing appointments.</param>
    /// <param name="userManager">The user manager for managing user information.</param>
    public CreateAppointmentHandler(IAppointmentRepository appointmentRepository, UserManager<User> userManager)
    {
        _appointmentRepository = appointmentRepository;
        _userManager = userManager;
    }

    /// <summary>
    /// Handles the creation of a new appointment based on the provided command.
    /// </summary>
    /// <param name="request">The command containing appointment creation details.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A response containing the appointment ID and a success message.</returns>
    public async Task<CreateAppointmentResponse> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        // Fill user information if UserId is provided and user is authenticated
        if (!string.IsNullOrEmpty(request.UserId))
        {
            var user = await _userManager.FindByIdAsync(request.UserId) ?? throw new NotFoundException("User not found.");

            request.Name = user.FirstName;
            request.LastName = user.LastName;
            request.Email = user.Email;
            request.PhoneNumber = user.PhoneNumber;
        }

        var appointment = new Appointment
        {
            Id = Guid.NewGuid(),
            ProjectId = request.ProjectId,
            AgentId = request.AgentId.Value,
            AppointmentDate = request.AppointmentDate,
            UserId = request.UserId,
            Name = request.Name,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber
        };

        await _appointmentRepository.InsertAsync(appointment);
        await _appointmentRepository.SaveAsync();

        return new CreateAppointmentResponse
        {
            AppointmentId = appointment.Id,
            Message = "Appointment created successfully."
        };
    }
}