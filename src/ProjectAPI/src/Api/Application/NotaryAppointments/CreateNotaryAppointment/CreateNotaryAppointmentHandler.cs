using ProjectAPI.Api.Application.Common.Exceptions;
using ProjectAPI.Domain.Appointments.Entities;
using ProjectAPI.Domain.Appointments.Interfaces;
using ProjectAPI.Domain.Reservations.Interface;
using ProjectAPI.Domain.Users.Interfaces;
namespace ProjectAPI.Api.Application.NotaryAppointments.CreateNotaryAppointment;

public class CreateNotaryAppointmentHandler : IRequestHandler<CreateNotaryAppointmentCommand, CreateNotaryAppointmentResponse>
{
    private readonly INotaryAppointmentRepository _notaryAppointmentRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IPerformanceIndicatorRepository _performanceIndicatorRepository;

    public CreateNotaryAppointmentHandler(
        INotaryAppointmentRepository notaryAppointmentRepository,
        IReservationRepository reservationRepository,
        IPerformanceIndicatorRepository performanceIndicatorRepository)
    {
        _notaryAppointmentRepository = notaryAppointmentRepository;
        _reservationRepository = reservationRepository;
        _performanceIndicatorRepository = performanceIndicatorRepository;
    }

    public async Task<CreateNotaryAppointmentResponse> Handle(CreateNotaryAppointmentCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetByIDAsync(request.ReservationId)
                          ?? throw new NotFoundException($"Reservation with ID {request.ReservationId} not found.");

        var notaryAppointment = new NotaryAppointment
        {
            Id = Guid.NewGuid(),
            BuyerId = request.BuyerId,
            NotaireId = request.NotaireId,
            AgentId = request.AgentId,
            ConnectedUserId = request.ConnectedUserId,
            ReservationId = request.ReservationId,
            AppointmentDate = request.AppointmentDate,
            Status = request.Status,
            BuyerFirstName = reservation.Name,
            BuyerLastName = reservation.LastName,
            BuyerCIN = reservation.CIN,
            BuyerEmail = reservation.Email,
            BuyerPhoneNumber = reservation.PhoneNumber,
            PropertyPrice = reservation.TotalPropertyPrice,
            TaxFees = request.TaxFees,
            TahfidFees = request.TahfidFees
        };

        await _notaryAppointmentRepository.InsertAsync(notaryAppointment);

        // Increment leads for the agent associated with the reservation
        if (!string.IsNullOrEmpty(request.AgentId))
        {
            var performanceIndicator = await _performanceIndicatorRepository.Find(pi=>pi.AgentId ==request.AgentId);
            if (performanceIndicator != null && performanceIndicator.Any())
            {
                performanceIndicator.FirstOrDefault()!.IncrementLeadsGenerated();
                await _performanceIndicatorRepository.SaveAsync();
            }
        }

        await _notaryAppointmentRepository.SaveAsync();

        return new CreateNotaryAppointmentResponse
        {
            Id = notaryAppointment.Id,
            Message = "Notary appointment created successfully."
        };
    }
}

