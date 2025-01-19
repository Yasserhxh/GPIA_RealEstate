using ProjectAPI.Api.Application.Common.Exceptions;
using ProjectAPI.Domain.Reservations.Interface;

namespace ProjectAPI.Api.Application.Reservations.GetReservationById
{
    public class GetReservationByIdHandler : IRequestHandler<GetReservationByIdQuery, GetReservationByIdResponse>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetReservationByIdHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<GetReservationByIdResponse> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIDAsync(request.ReservationId)
                ?? throw new NotFoundException($"Reservation with ID {request.ReservationId} not found.");

            return new GetReservationByIdResponse
            {
                Id = reservation.Id,
                BuyerId = reservation.BuyerId,
                Name = reservation.Name,
                LastName = reservation.LastName,
                CIN = reservation.CIN,
                Email = reservation.Email,
                PhoneNumber = reservation.PhoneNumber,
                UnitId = reservation.UnitId,
                UnitDetails = reservation.UnitDetails,
                AgentId = reservation.AgentId,
                TotalPropertyPrice = reservation.TotalPropertyPrice,
                ReservationAmount = reservation.ReservationAmount,
                ReservationDate = reservation.ReservationDate,
                IsUnderConstruction = reservation.IsUnderConstruction
            };
        }
    }
}
